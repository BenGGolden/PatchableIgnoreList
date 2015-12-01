using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;

namespace Sitecore.Modules.PatchableIgnoreList
{
    public class PatchableIgnoreList : HttpRequestProcessor
    {
        private readonly IPrefixSet _prefixSet;

        public PatchableIgnoreList() : this(new PrefixTrie(), true)
        {
        }

        public PatchableIgnoreList(IPrefixSet prefixSet, string loadIgnoreUrlPrefixes)
            : this(prefixSet, !loadIgnoreUrlPrefixes.Equals(bool.FalseString, StringComparison.OrdinalIgnoreCase))
        {
        }

        public PatchableIgnoreList(IPrefixSet prefixSet, bool loadIgnoreUrlPrefixes)
        {
            Assert.ArgumentNotNull(prefixSet, "prefixSet");
            _prefixSet = prefixSet;
            if (loadIgnoreUrlPrefixes)
            {
                _prefixSet.InsertRange(Settings.IgnoreUrlPrefixes);
            }
        }

        public void AddPrefix(string prefix)
        {
            _prefixSet.Insert(prefix);
        }

        public override void Process(HttpRequestArgs args)
        {
            if (_prefixSet.ContainsPrefix(args.Url.FilePath))
            {
                args.AbortPipeline();
            }
        }
    }
}