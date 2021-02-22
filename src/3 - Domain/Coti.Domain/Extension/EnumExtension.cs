using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Coti.Domain.Extension
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            MemberInfo member = type.GetMembers().Where(w => w.Name == Enum.GetName(type, value)).FirstOrDefault();
            var attribute = member?.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

            return attribute?.Description != null ? attribute.Description : value.ToString();
        }

        // public static string GetDescription(this Enum enumerationValue)
        // {
        //     Type type = enumerationValue.GetType();
        //     MemberInfo member = type.GetMembers().Where(w => w.Name == Enum.GetName(type, enumerationValue)).FirstOrDefault();
        //     var attribute = member?.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
        //     return attribute?.Description != null ? attribute.Description : enumerationValue.ToString();
        // }

        //public static string GetDescription(this Enum value)
        //{
        //    FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
        //    if (fieldInfo == null) return null;
        //    var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));

        //    return attribute.Description;
        //}
    }
}
