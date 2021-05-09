using System;
using System.ComponentModel;

namespace Messages.Core.Enums.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo is null)
                return string.Empty;

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }
    }
}
