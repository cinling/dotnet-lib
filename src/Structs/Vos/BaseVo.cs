﻿using System;
using Cinling.Lib.Interfaces;

namespace Cinling.Lib.Structs.Vos {
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVo : IOnInit, IDisposable {

        public BaseVo() {
            OnInit();    
        }
        
        public void OnInit() {
            
        }

        public void Dispose() {
            
        }
    }
}