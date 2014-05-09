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
            var items = Enum.GetValues(typeof(T));
            var result = new List<IEnumItem>();
            foreach (var item in items)
            {
                var name = item.ToString();

                var mi = typeof(T).GetMember(name).First();
                var dtAttribute =  mi.GetCustomAttributes(typeof(DisplayTextAttribute), false).FirstOrDefault();
                
                if (dtAttribute !=null)
                {
                    name = (dtAttribute as DisplayTextAttribute).DisplayText;
                }
                var vt = new EnumItem { Value = (int)item, Text = name };
                result.Add(vt);
            }
            return result.ToArray();
        }
    }
}
