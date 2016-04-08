using System;
using System.Text.RegularExpressions;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class PatternRule : CanonicalUrlRuleBase
    {
        private readonly Regex _regex;
        private readonly string _replacement;

        public PatternRule(string regex, string replacement)
        {
            _regex = new Regex(regex, RegexOptions.Compiled);
            _replacement = replacement;
        }

        protected override void ApplyRule(UriBuilder uri)
        {
            uri.Path = _regex.Replace(uri.Path, _replacement);
        }
    }
}