using System.Collections.Generic;

namespace Sitecore.Modules.PatchableIgnoreList
{
    public class PrefixTrie : IPrefixSet
    {
        private readonly TrieNode _root;

        public PrefixTrie()
        {
            _root = new TrieNode('\0');
        }

        public virtual bool ContainsPrefix(string prefix)
        {
            var upperPrefix = prefix.ToUpperInvariant();
            var currentNode = _root;

            foreach (var c in upperPrefix)
            {
                currentNode = currentNode[c];
                if (currentNode == null)
                {
                    return false;
                }

                if (currentNode.IsLeaf())
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void InsertRange(IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                Insert(item);
            }
        }

        public virtual void Insert(string prefix)
        {
            if (ContainsPrefix(prefix)) return;

            var upperPrefix = prefix.ToUpperInvariant();
            var parent = _root;
            foreach (var c in upperPrefix)
            {
                var child = parent[c];
                if (child == null)
                {
                    child = new TrieNode(c);
                    parent.Children.Add(child);
                }

                parent = child;
            }
        }
    }
}