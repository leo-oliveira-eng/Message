using System;
using System.ComponentModel;
using System.Linq;

namespace Messages.Core.Enums.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
                return string.Empty;

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Any() 
                ? attributes.First().Description 
                : value.ToString();
        }
    }
}
