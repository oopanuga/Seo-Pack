using System;

namespace SeoPack.Url.Canonicalization
{
    public class CustomUrlBuilder : UriBuilder
    {
        public CustomUrlBuilder(string uri):base(uri)
        {

        }

        public CustomUrlBuilder(Uri uri):base(uri)
        {
        }

        private string _path;
        public new string Path
        {
            get
            {
                if (_path == string.Empty)
                    return _path;
                else
                    return base.Path;
            }
            set
            {
                if (value == string.Empty)
                    _path = value;
                else
                    base.Path = value;
            }
        }

        public new Uri Uri { get; set; }
    }
}
