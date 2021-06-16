using Cinling.Lib.Interfaces;

namespace Cinling.Lib.Structs.Vos {
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVo : IOnInit {

        public BaseVo() {
            OnInit();    
        }
        
        public void OnInit() {
            
        }
    }
}