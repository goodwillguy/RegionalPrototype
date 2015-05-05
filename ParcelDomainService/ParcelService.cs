using Parcel.Common.Factory;
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
        private RegionalParcelDomainFactory _domianFactory;

        public ParcelService()
            : base(Bootstrapper.Container)
        {

            _domianFactory = _container.GetInstance(typeof(RegionalParcelDomainFactory)) as RegionalParcelDomainFactory;
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
            var singaporeInstance = _domianFactory.GetRegionalInstance(parcelData);

            singaporeInstance.PickupParcel(Guid.Empty,"test");
            return false;
        }
    }
}