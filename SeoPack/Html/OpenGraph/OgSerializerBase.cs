﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Html.OpenGraph
{
    public abstract class OgSerializerBase<T>
    {
        List<OgProperty> _properties;

        protected OgSerializerBase()
        {
            _properties = new List<OgProperty>();
        }

        public T Serialize(Og og)
        {
            if (og == null)
            {
                throw new ArgumentNullException("og");
            }

            BuildOpenGraphData(og);

            return Serialize(_properties);
        }

        protected abstract T Serialize(IEnumerable<OgProperty> properties);

        private void BuildOpenGraphData(object obj)
        {
            var type = obj.GetType();

            foreach (var property in type.GetProperties())
            {
                //
                var ogpAttributes = property
                    .GetCustomAttributes(typeof(OgPropertyAttribute), true) as OgPropertyAttribute[];

                var propertTypeIsComplex = false;
                if (ogpAttributes != null && ogpAttributes.Length > 0)
                {
                    var propertyType = property.PropertyType;

                    // if property returns a complex type then call function recursively
                    if (!propertyType.Equals(typeof(string)) && !propertyType.IsPrimitive)
                    {
                        var propertyValue = property.GetValue(obj, null);
                        if (propertyValue == null) continue;

                        BuildOpenGraphData(property.GetValue(obj, null));
                        propertTypeIsComplex = true;
                    }

                    var ogName = ogpAttributes[0].Name;
                    var ogValue = property.GetValue(obj, null);

                    // if its a structured property and if the ogproperty name is represented as a property
                    // on of the structured property then move to the next item on the list
                    if (propertTypeIsComplex &&
                        _properties.Any(x => x.Name.Equals(ogName, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }

                    if (ogValue != null && !ogValue.Equals(GetTypeDefaultValue(ogValue.GetType())))
                    {
                        BuildOpenGraphData(ogName, ogValue);
                    }
                }
            }
        }

        private void BuildOpenGraphData(string propertyName, object content)
        {
            if (content.GetType() != typeof(string) && content is IEnumerable)
            {
                var contentList = (IEnumerable)content;

                foreach (object item in contentList)
                {
                    _properties.Add(new OgProperty(propertyName, item.ToString()));
                }
            }
            else if (content is DateTime || content is DateTime?)
            {
                var dateContent = DateTime.Parse(content.ToString());
                if ((dateContent.Hour == 0) && (dateContent.Minute == 0) && (dateContent.Second == 0))
                {
                    _properties.Add(new OgProperty(propertyName, dateContent.ToString("yyyy-MM-dd")));
                }
                else
                {
                    _properties.Add(new OgProperty(propertyName, dateContent.ToString("s") + "Z"));
                }
            }
            else
            {
                _properties.Add(new OgProperty(propertyName, content.ToString()));
            }
        }

        private object GetTypeDefaultValue(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
