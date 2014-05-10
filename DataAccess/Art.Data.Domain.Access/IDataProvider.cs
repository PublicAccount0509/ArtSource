using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access
{
    public interface IDataProvider
    { 
        void InitDatabase(string sqlCommandFile);
    }
}
