using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core.Enums
{
    public class EnumItem : IEnumItem, IValueTextEntry
    {
        public string Text { get; set; }

        public int Value { get; set; }

        public int? Order { get; set; }
    }
}
