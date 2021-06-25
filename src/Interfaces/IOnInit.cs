using System;

namespace Cinling.Lib.Interfaces {
    
    [Obsolete]
    public interface IOnInit {
        void OnInit();
    }

    public static class OnInitMethods {
        public static void onInit(this IOnInit ins) {
        }
    }
}