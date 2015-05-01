using Parcel.Common.Interface;
using SimpleInjector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace Parcel.Common.Factory
{
    public class ParcelDbContextFactory : IDbContextFactory
    {
        IDictionary<string, string> _dbContextRegionAndType = null;
        IConnectionString _connectionString = null;
        Container _container = null;
        public ParcelDbContextFactory(IConnectionString connectionString,SimpleInjector.Container container)
        {
            if (connectionString==null)
            {
                throw new Exception("Cannot have null values");
            }
           // _dbContextRegionAndType = dbContextRegionAndType;
            _connectionString = connectionString;
            _container = container;
        }

        Dictionary<string, IDataModelService<IRegionalConfiguration>> dbContextCollection = new Dictionary<string, IDataModelService<IRegionalConfiguration>>();

        public Tz.Common.IDataModelService<IRegionalConfiguration> GetDbContext(string region)
        {
            IDataModelService<IRegionalConfiguration> dbContext = null;

            if (dbContextCollection.ContainsKey(region))
            {
                dbContext = dbContextCollection[region];
            }
            else
            {
               switch(region.ToLower())
               {
                   case "singapore":
                       dbContext = _container.GetInstance<IDataModelService<ISingaporeRegion>>() as IDataModelService<IRegionalConfiguration>;
                       break;

                   case "hongkong":
                       dbContext = _container.GetInstance<IDataModelService<IHongkongRegion>>() as IDataModelService<IRegionalConfiguration>;
                       break;
               }

               dbContextCollection.Add(region, dbContext);
                //Type dbContextType= Activator.CreateInstance()
            }

            return dbContext;
        }
    }
}
