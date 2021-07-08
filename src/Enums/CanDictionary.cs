namespace Cinling.Lib.Enums {
    
    public enum CanDictionary {
        /// <summary>
        /// Underscore. Convert the data to underline style.
        /// 下划线。将数据转为下划线风格。
        /// 
        /// Such as: [Name => name] [MyName => my_name] [myName => my_name] 
        /// 如：[Name => name] [MyName => my_name] [myName => my_name] 
        /// </summary>
        Underscore,
        /// <summary>
        /// UpperCamelCase
        /// </summary>
        UpperCamelCase,
        /// <summary>
        /// LowerCamelCase
        /// </summary>
        LowerCamelCase
    }
}