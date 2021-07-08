using System;
using NUnit.Framework;

namespace LibTest {
    
    
    public class JustTest {

        [Test]
        public void Test1() {
            var str = "a";
            str.ToUpper();
            Console.Out.Write(str);
        }
    }
}