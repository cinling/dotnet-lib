using Cinling.Lib.Extensions;
using NUnit.Framework;

namespace LibTest.Extensions {
    
    
    public class StringExtensionsTest {

        [Test]
        public void ToUnderscore() {
            Assert.AreEqual("string_extensions_test", "StringExtensionsTest".ToUnderscore());
        }

        [Test]
        public void UpperCamelCase() {
            Assert.AreEqual("StringExtensionsTest", "string_extensions_test".ToUpperCamelCase());
        }

        [Test]
        public void LowerCamelCase() {
            Assert.AreEqual("stringExtensionsTest", "string_extensions_test".ToLowerCamelCase());
        }
    }
}