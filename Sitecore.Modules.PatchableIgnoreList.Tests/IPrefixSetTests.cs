using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sitecore.Modules.PatchableIgnoreList.Tests
{
    public abstract class IPrefixSetTests<T> where T : IPrefixSet
    {
        public abstract T GetPrefixSet();

        [Fact]
        public void ContainsPrefix_WhenEmpty_ReturnsFalse()
        {
            // Arrange
            var prefixSet = GetPrefixSet();

            // Act
            var result = prefixSet.ContainsPrefix("/Any/String");

            // Assert
            Assert.False(result);
        }

        [Theory, MemberData("TrieTestData")]
        public void ContainsPrefix_WithDataAfterInsertRange_ReturnsAsExpected(string[] prefixesToInsert,
            string stringToTest, bool expectedResult)
        {
            // Arrange
            var prefixSet = GetPrefixSet();
            prefixSet.InsertRange(prefixesToInsert);

            // Act
            var result = prefixSet.ContainsPrefix(stringToTest);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> TrieTestData => new[]
        {
            new object[] {PrefixesToInsert, "/prefix/one", true},
            new object[] {PrefixesToInsert, "/prefix/two/and/more", true},
            new object[] {PrefixesToInsert, "/prefix/three/", true},
            new object[] {PrefixesToInsert, "and/anotherthing", true},
            new object[] {PrefixesToInsert, "/PreFiX/ONE", true},
            new object[] {PrefixesToInsert, "/PreFiX/Two/And/More", true},
            new object[] {PrefixesToInsert, "prefix/one", false},
            new object[] {PrefixesToInsert, "/prefix/thr", false},
            new object[] {PrefixesToInsert, "Something Totally different", false},
            new object[] {PrefixesToInsert, "some/other/string", false}
        };

        public static readonly string[] PrefixesToInsert =
        {
            "/prefix/one",
            "/Prefix/Two",
            "/prefix/three",
            "some/other/prefix",
            "and/another",
        };
    }
}
