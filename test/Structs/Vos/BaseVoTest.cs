using System;
using System.Collections.Generic;
using Cinling.Lib.Structs.Vos;
using Newtonsoft.Json;
using NUnit.Framework;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LibTest.Structs.Vos {
    
    /// <summary>
    /// 
    /// </summary>
    public class BaseVoTest {

        /**
         * ICanDictionary 接口测试
         */
        [Test]
        public void CanDictionary() {
            // Test1
            var vo = new AppleVo {Weight = 1.1f, Color = "red"};
            var voDict = new Dictionary<string, object> {{"Weight", 1.1f}, {"Color", "red"}};
            var vo1 = new AppleVo();
            vo1.SetByDictionary(voDict);
            Assert.AreEqual(vo.ToDictionary(), voDict);
            Assert.AreEqual(vo1.ToDictionary(), voDict);
            vo1.Color = "yellow";
            Assert.AreNotEqual(vo1.ToDictionary(), voDict);
            
            
            // Test2
            var branchVo = new AppleBranchVo {LeafNum = 100};
            branchVo.AppleVoList.Add(new AppleVo {Weight = 1.0f, Color = "red"});
            branchVo.AppleVoList.Add(new AppleVo {Weight = 1.2f, Color = "green"});
            var branchVoDict = new Dictionary<string, object> {
                {"LeafNum", 100}, {
                    "AppleVoList", new List<Dictionary<string, object>> {
                        new() {
                            {"Weight", 1.0f},
                            {"Color", "red"}
                        },
                        new() {
                            {"Weight", 1.2f},
                            {"Color", "green"}
                        }
                    }
                }
            };
            var branchVo1 = new AppleBranchVo();
            branchVo1.SetByDictionary(branchVoDict);
            Assert.AreEqual(branchVo.ToDictionary(), branchVoDict);
            Assert.AreEqual(branchVo1.ToDictionary(), branchVoDict);
            branchVo1.LeafNum = 101;
            Assert.AreNotEqual(branchVo1.ToDictionary(), branchVoDict);
            
            // Test3
            var treeVo = new AppleTreeVo {
                Height = 100f,
                branchVoListDict = {
                    {"First", new List<AppleBranchVo> {
                        new() {
                            LeafNum = 100,
                            AppleVoList = {
                                new AppleVo {Weight = 1.0f, Color = "red"},
                                new AppleVo {Weight = 1.2f, Color = "green"}
                            }
                        },
                        new () {
                            LeafNum = 200,
                            AppleVoList = {
                                new AppleVo {Weight = 2.0f, Color = "red"},
                                new AppleVo {Weight = 2.2f, Color = "green"}
                            }
                        }
                    }},
                    {"Second", new List<AppleBranchVo> {
                        new() {
                            LeafNum = 100,
                            AppleVoList = {
                                new AppleVo {Weight = 1.0f, Color = "red"},
                                new AppleVo {Weight = 1.2f, Color = "green"}
                            }
                        },
                        new () {
                            LeafNum = 200,
                            AppleVoList = {
                                new AppleVo {Weight = 2.0f, Color = "red"},
                                new AppleVo {Weight = 2.2f, Color = "green"}
                            }
                        }
                    }}
                }
            };
            // var treeVoDict = 
            // Assert.AreEqual(treeVo.ToDictionary(), );
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
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, List<AppleBranchVo>> branchVoListDict { get; } = new();
        /// <summary>
        /// 
        /// </summary>
        public float Height { get; set; }
    }
}