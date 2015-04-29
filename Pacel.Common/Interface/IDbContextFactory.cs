using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;

namespace Pacel.Common.Interface
{
    public interface IDbContextFactory
    {
        IDataModelService GetDbContext(string region);
    }
}
