using Pacel.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;

namespace ParcelBusiness_Singapore
{
    public class ParcelDomain : IParcelDomain
    {
        private readonly IConnectionString globalConnection;
        private readonly IDbContextFactory dbContextFactory;
        public ParcelDomain(IConnectionString connectionString,IDbContextFactory dbContextFactory)
        {
            globalConnection = connectionString;
        }
        public bool PickupParcel(Guid parcelId, string parcelData)
        {
            bool isSuccess = false;



            return isSuccess;
        }
    }
}
