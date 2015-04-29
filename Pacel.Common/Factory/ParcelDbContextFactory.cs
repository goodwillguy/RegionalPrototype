using Pacel.Common.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;

namespace Pacel.Common.Factory
{
    public class ParcelDbContextFactory : IDbContextFactory
    {
        IDictionary<string, string> _dbContextRegionAndType = null;

        public ParcelDbContextFactory(IDictionary<string,string> dbContextRegionAndType)
        {
            if(dbContextRegionAndType == null || dbContextRegionAndType.Count()==0)
            {
                throw new Exception("Cannot have null values");
            }
            _dbContextRegionAndType = dbContextRegionAndType;
        }

        Dictionary<string, IDataModelService> dbContextCollection = new Dictionary<string, IDataModelService>();

        public Tz.Common.IDataModelService GetDbContext(string region)
        {
            IDataModelService dbContext = null;



            return dbContext;
        }
    }
}
