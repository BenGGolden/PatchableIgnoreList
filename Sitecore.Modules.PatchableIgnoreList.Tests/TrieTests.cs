using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sitecore.Modules.PatchableIgnoreList.Tests
{
    public class TrieTests : IPrefixSetTests<PrefixTrie>
    {
        public override PrefixTrie GetPrefixSet()
        {
            return new PrefixTrie();
        }
    }
}
