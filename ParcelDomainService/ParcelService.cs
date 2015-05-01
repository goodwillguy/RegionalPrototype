using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Tz.Common;

namespace ParcelDomainService
{
    public class ParcelService : SelfHostedWCF, IParcelService
    {
        public ParcelService()
            : base(Bootstrapper.Container)
        {
        }

        void InitialiseComponents()
        {

        }


        public void CreateAndReservceParcel(string region)
        {
            
        }

        public string GetFirstParcel(string region)
        {
            return "test";
        }

        public bool PickupParcel(Guid parcelId, string parcelData)
        {
            return false;
        }
    }
}