namespace Cinling.Lib.Interfaces {
    public interface IOnInit {
        void onInit();
    }

    public static class OnInitMethods {
        public static void onInit(this IOnInit ins) {
        }
    }
}