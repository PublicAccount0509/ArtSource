using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace WebExpress.Core
{
    public static class EnumExtenstion
    {
        public static IEnumItem[] GetEnumItems<T>()
        {
            return GetEnumItems(typeof(T));
        }

        public static IEnumItem GetEnumItem(Type enumType, Enum item)
        {
            var name = item.ToString();

            var mi = enumType.GetMember(name).First();
            var dtAttribute = mi.GetCustomAttributes(typeof(DisplayTextAttribute), false).FirstOrDefault();

            var text = string.Empty;
            if (dtAttribute != null)
            {
                text = (dtAttribute as DisplayTextAttribute).DisplayText;
            }
            var enumItem = new EnumItem { Value = Convert.ToInt32(item), Name = item.ToString(), Text = text };
            return enumItem;
        }

        public static IEnumItem[] GetEnumItems(Type enumType)
        {
            var items = Enum.GetValues(enumType);
            var result = new List<IEnumItem>();
            foreach (var item in items)
            {
                var enumItem = GetEnumItem(enumType, item as Enum);
                result.Add(enumItem);
            }
            return result.ToArray();
        }
    }
}
