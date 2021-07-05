namespace System {


    public static class CinlingLibTypeExtensions {
        
        /// <summary>
        /// 判断
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static bool IsImplementsBy(this Type type, Type interfaceType) {
            var interfaces = type.GetInterfaces();
            for (var i = 0; i < interfaces.Length; i++) {
                if (interfaces[i] == interfaceType) {
                    return true;
                }
            }
            return false;
        }
    }
}