using System;
using System.Collections.Generic;
using Cinling.Lib.Attributes;
using Cinling.Lib.Enums;
using Cinling.Lib.Structs.Vos;
using NUnit.Framework;

namespace LibTest.Attributes {
    
    public class CanDictionaryPropertyAttributeTest {

        [Test]
        public void Test() {
            var vo = new PropertyVo {UnderScore = "1", LowerCamelCase = "2", CustomName = "3"};
            var dict = new Dictionary<string, object> {
                {"under_score", "1"},
                {"lowerCamelCase", "2"},
                {"customname", "3"}
            };
            Assert.AreEqual(dict, vo.ToDictionary());

            var vo2 = new PropertyVo();
            vo2.SetByDictionary(dict);
            Assert.AreEqual(dict, vo2.ToDictionary());
            Assert.AreEqual(vo.ToJson(), vo2.ToJson());
        }
    }

    [CanDictionaryClass(CanDictionary.Underscore)]
    public class PropertyVo : BaseVo {
        public string UnderScore { get; set; }
        
        [CanDictionaryProperty(CanDictionary.LowerCamelCase)]
        public string LowerCamelCase { get; set; }
        
        [CanDictionaryProperty("customname")]
        public string CustomName { get; set; }
    }
}