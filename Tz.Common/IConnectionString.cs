using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Common
{
    public interface IConnectionString
    {
        string ConnectionString(string region);
    }
}
