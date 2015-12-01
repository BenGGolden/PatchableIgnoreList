# PatchableIgnoreList
A replacement for Sitecore's IgnoreList processor for the httpRequestBegin pipeline.

The standard IgnoreList processor for Sitecore's httpRequestBegin pipeline reads its prefixes
from a configuration setting.  Since it is a single string value, it can't be patched easily by
config files in the /App_Config/Include folder.

The PatchableIgnoreList fixes this problem by replacing the standard processor with one that can
read prefixes from a configuration property list.  By default, the PatchableIgnoreList uses a
trie datastructure instead of a simple string array to improve performance of lookups.
