using System;
using System.Collections.Generic;
using Cinling.Lib.Structs.Oos;
using NUnit.Framework;

namespace LibTest.Structs.Oos {
    
    
    public class BaseOoTest {

        [Test]
        public void All() {
            var oo = new Oo();
            var dict = new Dictionary<string, object> {
                {"Name", "Ben"},
                {"Age", 20},
            };
            oo.SetByDictionary(dict);
            Assert.AreEqual("Ben", oo.GetParam("Name"));
            Assert.AreEqual(20, oo.GetParam("Age"));

            oo.TryGetParam("Age", out var value);
            Assert.AreEqual(20, value);
        }
    }

    public class Oo : BaseOo {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}