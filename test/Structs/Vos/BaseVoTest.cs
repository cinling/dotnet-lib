using System.Collections.Generic;
using Cinling.Lib.Interfaces;
using Cinling.Lib.Structs.Vos;
using NUnit.Framework;

namespace LibTest.Structs.Vos {
    
    /// <summary>
    /// 
    /// </summary>
    public class BaseVoTest {

        [Test]
        public void ToDict() {
            // Test1
            var vo = new AppleVo {Weight = 1.1f, Color = "red"};
            Assert.AreEqual(vo.ToDictionary(), new Dictionary<string, object> {{"Weight", 1.1f}, {"Color", "red"}});
            
            // Test2
            var branchVo = new AppleBranchVo {LeafNum = 100};
            branchVo.AppleVoList.Add(new AppleVo {Weight = 1.0f, Color = "red"});
            branchVo.AppleVoList.Add(new AppleVo {Weight = 1.2f, Color = "green"});
            Assert.AreEqual(branchVo.ToDictionary(), new Dictionary<string, object> {
                {"LeafNum", 100},
                {"AppleVoList", new List<Dictionary<string, object>> {
                    new() {
                        {"Weight", 1.0f},
                        {"Color", "red"}
                    },
                    new () {
                        {"Weight", 1.2f},
                        {"Color", "green"}
                    }
                }}
            });
        }
    }

    public class AppleVo : BaseVo {
        public float Weight { get; set; }
        public string Color { get; set; }
    }

    public class AppleBranchVo : BaseVo {
        public int LeafNum { get; set; }
        public List<AppleVo> AppleVoList { get; } = new();
    }

    public class AppleTreeVo : BaseVo {
        public Dictionary<string, List<AppleBranchVo>> branchVoListDict { get; } = new();
    }
}