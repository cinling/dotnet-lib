using Cinling.Lib.Helpers;
using NUnit.Framework;

namespace LibTest.Helpers {
    public class EncryptHelperTest {

        [Test]
        public void TestSha1() {
            Assert.IsTrue("7C4A8D09CA3762AF61E59520943DC26494F8941B" == EncryptHelper.Sha1("123456"));
            Assert.IsTrue("48058E0C99BF7D689CE71C360699A14CE2F99774" == EncryptHelper.Sha1("121212"));
        }

        [Test]
        public void TestSha512() {
            Assert.IsTrue("BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413" == EncryptHelper.Sha512("123456"));
            Assert.IsTrue("C45A0A774BD38FFD4634CA52B568934686286911216A22D8B85DF262E8ACEA07F190E9D4470FDE92E67CCEF462A849F24713B310C58AC992FBA4BBAE9B0B3A86" == EncryptHelper.Sha512("121212"));
        }
        
    }
}