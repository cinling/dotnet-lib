using Cinling.Lib.Utils;
using NUnit.Framework;

namespace LibTest.Utils {
    
    public class JsonUtilTest {

        [Test]
        public void encode() {
            var obj = new {a = 1, b = "2"};
            var objJson = JsonUtil.encode(obj);
            Assert.IsTrue(objJson == "{\"a\":1,\"b\":\"2\"}");
        }
    }
}