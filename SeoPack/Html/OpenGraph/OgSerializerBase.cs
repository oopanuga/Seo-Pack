using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SeoPack.Html.OpenGraph
{
    /// <summary>
    /// Represents a class that serializes an open graph object to the typeof T.
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    public abstract class OgSerializerBase<T>
    {
        List<OgProperty> _properties;

        /// <summary>
        /// Initialises the OgSerializerBase class.
        /// </summary>
        protected OgSerializerBase()
        {
            _properties = new List<OgProperty>();
        }

        /// <summary>
        /// Serializes the supplied open graph object to the typeof T.
        /// </summary>
        /// <param name="og">The opengraph object to serialize.</param>
        /// <returns>The serialized open graph object.</returns>
        public T Serialize(Og og)
        {
            if (og == null)
            {
                throw new ArgumentNullException("og");
            }

            AddOgPropertiesToList(og);

            return Serialize(_properties);
        }

        /// <summary>
        /// Serializes the supplied open graph object to the typeof T. Derived types provide
        /// an implementation for this Serialize overload.
        /// </summary>
        /// <param name="properties">An enumerable list of open graph properties.</param>
        /// <returns>The serialized open graph object.</returns>
        protected abstract T Serialize(IEnumerable<OgProperty> properties);

        #region Helper Methods

        private void AddOgPropertiesToList(object obj)
        {
            var type = obj.GetType();

            var filteredAndOrderedProperties = type.GetProperties()
                .Where(x => x.IsOgMetadata())
                .OrderBy(x => x.OgMetadataOrder());

            foreach (var property in filteredAndOrderedProperties)
            {
                var ogspAttributes = property.GetCustomAttributes(
                    typeof(OgStructuredPropertyAttribute), true) as OgStructuredPropertyAttribute[];

                if (ogspAttributes != null && ogspAttributes.Length > 0)
                {
                    var propertyType = property.PropertyType;

                    if (!propertyType.Equals(typeof(string)) && !propertyType.IsPrimitive)
                    {
                        var propertyValue = property.GetValue(obj, null);
                        if (propertyValue == null) continue;

                        if (propertyValue.GetType() != typeof(string) && propertyValue is IEnumerable)
                        {
                            var propertyValueList = (IEnumerable)propertyValue;

                            foreach (object pv in propertyValueList)
                            {
                                AddOgPropertiesToList(pv);
                            }
                        }
                        else
                        {
                            AddOgPropertiesToList(propertyValue);
                        }
                    }
                    else continue;
                }
                else
                {
                    var ogpAttributes = property
                        .GetCustomAttributes(typeof(OgPropertyAttribute), true) as OgPropertyAttribute[];

                    var ogName = ogpAttributes[0].Name;
                    var ogValue = property.GetValue(obj, null);

                    if (ogValue != null && !ogValue.Equals(GetTypeDefaultValue(ogValue.GetType())))
                    {
                        AddOgPropertyToList(ogName, ogValue);
                    }
                }
            }
        }

        private void AddOgPropertyToList(string propertyName, object content)
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
            else if (content.GetType().IsEnum)
            {
                var fi = content.GetType().GetField(content.ToString());
                var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if (attributes != null && attributes.Length > 0)
                {
                    _properties.Add(new OgProperty(propertyName, attributes[0].Description.ToLower()));
                }
                else
                {
                    _properties.Add(new OgProperty(propertyName, content.ToString().ToLower()));
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

        #endregion
    }
}
