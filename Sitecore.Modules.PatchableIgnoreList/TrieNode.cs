using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Sitecore.Modules.PatchableIgnoreList
{
    public class TrieNode
    {
        public char Value { get; }
        public List<TrieNode> Children { get; }

        public TrieNode(char value)
        {
            Value = value;
            Children = new List<TrieNode>();
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public TrieNode this[char c] => Children.FirstOrDefault(child => child.Value == c);
    }
}