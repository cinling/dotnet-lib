#nullable enable
namespace System {


    public static class TypeExtensions {
        
        /// <summary>
        /// 判断
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static bool IsImplements(this Type type, Type interfaceType) {
            var interfaces = type.GetInterfaces();
            for (var i = 0; i < interfaces.Length; i++) {
                if (interfaces[i] == interfaceType) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TInterfaceType"></typeparam>
        /// <returns></returns>
        public static bool IsImplements<TInterfaceType>(this Type type) => IsImplements(type, typeof(TInterfaceType));

        /// <summary>
        /// 使用类型新建一个对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object? CreateInstance(this Type type) => Activator.CreateInstance(type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInstance<T>(this Type type) {
            var ins = type.CreateInstance();
            return (T) ins!;
        }
    }
}