using System;
using System.Text.RegularExpressions;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class PatternPolicy : UrlPolicyBase
    {
        private readonly Regex _regex;
        private readonly string _replacement;

        public PatternPolicy(string regex, string replacement)
        {
            _regex = new Regex(regex, RegexOptions.Compiled);
            _replacement = replacement;
        }

        protected override void ApplyPolicy(UriBuilder uri)
        {
            uri.Path = _regex.Replace(uri.Path, _replacement);
        }
    }
}