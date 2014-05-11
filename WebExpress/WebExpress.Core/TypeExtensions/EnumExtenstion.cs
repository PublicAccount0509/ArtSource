using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core.Enums;

namespace WebExpress.Core.TypeExtensions
{
    public static class EnumExtenstion
    {
        public static IEnumItem[] GetEnumItems<T>()
        {
            return GetEnumItems(typeof(T));
        }

        public static IEnumItem[] GetEnumItems(Type enumType)
        {
            var items = Enum.GetValues(enumType);
            var result = new List<IEnumItem>();
            foreach (var item in items)
            {
                var name = item.ToString();

                var mi = enumType.GetMember(name).First();
                var dtAttribute = mi.GetCustomAttributes(typeof(DisplayTextAttribute), false).FirstOrDefault();

                var text = name;
                if (dtAttribute != null)
                {
                    text = (dtAttribute as DisplayTextAttribute).DisplayText;
                }
                var vt = new EnumItem { Value = (int)item, Name = item.ToString(), Text = text };
                result.Add(vt);
            }
            return result.ToArray();
        }
    }
}
