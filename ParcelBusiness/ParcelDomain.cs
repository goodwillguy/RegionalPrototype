using Parcel.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace ParcelBusiness_Singapore
{
    public class ParcelDomain : IParcelDomain<ISingaporeRegion>
    {
        private readonly IConnectionString globalConnection;
        private readonly IDbContextFactory _dbContextFactory;
        public ParcelDomain(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public bool PickupParcel(Guid parcelId, string parcelData)
        {
            bool isSuccess = false;



            return isSuccess;
        }
    }
}
