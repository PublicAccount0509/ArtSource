
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access
{
    public class EfHelper
    {
        public static void ParseItems<T>(ICollection<T> originalItems, IList<int> currentItemIds, ICollection<T> allItems) where T : BaseEntity
        {
            foreach (var item in allItems)
            {
                if (currentItemIds.Contains(item.Id))
                {
                    if (!originalItems.Any(i => i.Id == item.Id))
                    {
                        originalItems.Add(item);
                    }
                }
                else
                {
                    if (originalItems.Any(i => i.Id == item.Id))
                    {
                        originalItems.Remove(item);
                    }
                }
            }
        }
    }
}
