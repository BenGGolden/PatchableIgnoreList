using System.Collections.Generic;

namespace Sitecore.Modules.PatchableIgnoreList
{
    public interface IPrefixSet
    {
        bool ContainsPrefix(string prefix);
        void Insert(string prefix);
        void InsertRange(IEnumerable<string> items);
    }
}