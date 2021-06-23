using System;

namespace Cinling.Lib.Interfaces {
    
    /// <summary>
    /// 可克隆
    /// </summary>
    public interface ICloneWith {
        
    }

    /// <summary>
    /// 克隆方法
    /// </summary>
    public static class CloneWithExtensions {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cloneWith"></param>
        /// <param name="obj"></param>
        public static void CloneWith(this ICloneWith cloneWith, ICloneWith obj) {
            var type = cloneWith.GetType();
            var objType = obj.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties) {
                var objValue = objType.GetProperty(property.Name)?.GetValue(obj, null);
                property.SetValue(objValue, null);
            }
        }
    }
}