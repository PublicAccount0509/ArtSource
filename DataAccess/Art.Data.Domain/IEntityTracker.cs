using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public interface IEntityTracker
    {
        DateTime FADateTime { get; set; } //First Add
        string FAUserName { get; set; }
        DateTime? LCDateTime { get; set; } //Last Change
        string LCUserName { get; set; }
    }
}
