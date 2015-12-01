using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitecore.Modules.PatchableIgnoreList
{
    public class PrefixList : IPrefixSet
    {
        private readonly List<string> _prefixes;

        public PrefixList()
        {
            _prefixes = new List<string>();
        }

        public bool ContainsPrefix(string prefix)
        {
            return _prefixes.Any(p => prefix.StartsWith(p, StringComparison.OrdinalIgnoreCase));
        }

        public void Insert(string prefix)
        {
            if (!ContainsPrefix(prefix))
            {
                _prefixes.Add(prefix);
            }
        }

        public void InsertRange(IEnumerable<string> prefixes)
        {
            foreach (var prefix in prefixes)
            {
                Insert(prefix);
            }
        }
    }
}