using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Art.Common
{
    public class CommonValidator
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }
            return Regex.IsMatch(phoneNumber, @"^(13|14|15|16|18|19)\d{9}$");
        }
    }
}
