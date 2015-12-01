namespace Sitecore.Modules.PatchableIgnoreList.Tests
{
    public class PrefixListTests : IPrefixSetTests<PrefixList>
    {
        public override PrefixList GetPrefixSet()
        {
            return new PrefixList();
        }
    }
}