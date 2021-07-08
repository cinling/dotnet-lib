using System;
using System.Collections.Generic;
using Cinling.Lib.Structs.Ios;
using NUnit.Framework;

namespace LibTest.Structs.Ios {
    public class BaseIoTest {

        [Test]
        public void All() {
            var io = new Io1 {Name = "Ben"};
            io.SetExtendParams(new Dictionary<string, object> {
                {"Age", 10},
                {"Height", 170}
            });
            Assert.AreEqual( new Dictionary<string, object>() {
                {"Name", "Ben"},
                {"Age", 10},
                {"Height", 170}
            }, io.ToDictionary());
            
            Assert.AreNotEqual( new Dictionary<string, object>() {
                {"Name", "Ben"},
                {"Age", 11},
                {"Height", 170}
            }, io.ToDictionary());
            
            io.SetExtendParam("Age", 11);
            Assert.AreEqual( new Dictionary<string, object>() {
                {"Name", "Ben"},
                {"Age", 11},
                {"Height", 170}
            }, io.ToDictionary());
            
            io.SetExtendParam("Name", "Tom");
            Assert.AreEqual( new Dictionary<string, object>() {
                {"Name", "Ben"},
                {"Age", 11},
                {"Height", 170}
            }, io.ToDictionary());
        }
    }

    public class Io1 : BaseIo {
        public string Name { get; set; }
    }
}