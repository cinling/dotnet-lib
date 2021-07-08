using System.Collections.Generic;
using Cinling.Lib.Attributes;
using Cinling.Lib.Enums;
using Cinling.Lib.Structs.Vos;
using NUnit.Framework;

namespace LibTest.Attributes {
    
    /// <summary>
    /// 
    /// </summary>
    public class CanDictionaryClassAttributeTest {

        [Test]
        public void Underscore() {
            var vo = new UnderscoreVo {NuGet = "NuGet", UnitTest = "UnitTest"};
            var dict = new Dictionary<string, object>() {
                {"nu_get", "NuGet"},
                {"unit_test", "UnitTest"}
            };
            Assert.AreEqual(dict, vo.ToDictionary());

            var vo2 = new UnderscoreVo();
            vo2.SetByDictionary(dict);
            Assert.AreEqual("NuGet", vo2.NuGet);
            Assert.AreEqual("UnitTest", vo2.UnitTest);
        }

        [Test]
        public void UpperCamelCase() {
            var vo = new UpperCamelCaseVo {nu_get = "NuGet", unit_test = "UnitTest"};
            var dict = new Dictionary<string, object> {
                {"NuGet", "NuGet"},
                {"UnitTest", "UnitTest"}
            };
            Assert.AreEqual(dict, vo.ToDictionary());

            var vo2 = new UpperCamelCaseVo();
            vo2.SetByDictionary(dict);
            Assert.AreEqual("NuGet", vo2.nu_get);
            Assert.AreEqual("UnitTest", vo2.unit_test);
        }

        [Test]
        public void LowerCamelCase() {
            var vo = new LowerCamelCaseVo {nu_get = "NuGet", unit_test = "UnitTest"};
            var dict = new Dictionary<string, object> {
                {"nuGet", "NuGet"},
                {"unitTest", "UnitTest"}
            };
            Assert.AreEqual(dict, vo.ToDictionary());

            var vo2 = new LowerCamelCaseVo();
            vo2.SetByDictionary(dict);
            Assert.AreEqual("NuGet", vo2.nu_get);
            Assert.AreEqual("UnitTest", vo2.unit_test);
        }
    }

    [CanDictionaryClass(CanDictionary.Underscore)]
    public class UnderscoreVo : BaseVo {
        public string NuGet { get; set; }
        public string UnitTest { get; set; }
    }

    [CanDictionaryClass(CanDictionary.UpperCamelCase)]
    public class UpperCamelCaseVo : BaseVo {
        public string nu_get { get; set; }
        public string unit_test { get; set; }
    }

    [CanDictionaryClass(CanDictionary.LowerCamelCase)]
    public class LowerCamelCaseVo : BaseVo {
        public string nu_get { get; set; }
        public string unit_test { get; set; }
    }
}