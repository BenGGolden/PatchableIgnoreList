using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Configuration;

namespace Sitecore.Modules.PatchableIgnoreList
{
    public partial class PrefixSetBenchmark : System.Web.UI.Page
    {
        public double ListTime;
        public double TrieTime;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public double TimeTest(Func<string, bool> testFunc, IEnumerable<string> testData)
        {
            var watch = Stopwatch.StartNew();
            foreach (var str in testData)
            {
                testFunc(str);
            }
            watch.Stop();
            return watch.ElapsedTicks * 1000000000.0 / Stopwatch.Frequency;
        }

        public IEnumerable<string> GeneratePrefixes(int size)
        {
            for (var i = 0; i < size; i++)
            {
                yield return Guid.NewGuid().ToString();
            }
        }

        public IEnumerable<string> GenerateTestData(int size)
        {
            var l = Settings.IgnoreUrlPrefixes.Length;
            for (var i = 0; i < size; i++)
            {
                var prefix = i % l == 0 ? Settings.IgnoreUrlPrefixes[i / l % l] : "/Prefix/Not/In/List/";
                yield return prefix + Guid.NewGuid();
            }
        }

        protected void RunButton_OnClick(object sender, EventArgs e)
        {
            int prefixSetSize;
            if (!int.TryParse(PrefixSetSizeTextBox.Text, out prefixSetSize))
            {
                prefixSetSize = 10;
                PrefixSetSizeTextBox.Text = "10";
            }

            int testSetSize;
            if (!int.TryParse(TestSetSizeTextBox.Text, out testSetSize))
            {
                testSetSize = 1000;
                TestSetSizeTextBox.Text = "1000";
            }

            var list = new PrefixList();
            var trie = new PrefixTrie();

            var prefixes = GeneratePrefixes(prefixSetSize).ToArray();
            list.InsertRange(prefixes);
            trie.InsertRange(prefixes);

            var testData = GenerateTestData(testSetSize).ToArray();
            ListTime = TimeTest(list.ContainsPrefix, testData);
            TrieTime = TimeTest(trie.ContainsPrefix, testData);
        }
    }
}