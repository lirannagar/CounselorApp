using System;
using System.ComponentModel;

namespace CounselorApp
{
    public static class Enums
    {
        public enum ERole
        {
            [DescriptionAttribute("A100")]
            ADMIN_ROLE,
            [DescriptionAttribute("S100")]
            SECURITY_ADVISER
        }

        public static string GetDescription(Enum value)
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return value.ToString();
        }
    }
}
