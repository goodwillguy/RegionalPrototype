using Newtonsoft.Json;
using Tz.Singapore_ParcelPersistanceModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Parcel.Common.Interface;
using Tz.Parcel.Common.Interface.Repository;
using Tz.Parcel.Common.Service;
using Tz.ParcelDomainModel.Aggregate;
using Tz.Region;

namespace Tz.Singapore_ParcelDomainService
{
    public class ParcelDomain : IRegionalParcelDomainService<ISingaporeRegion>
    {
        private readonly IRegionalFactory _regionalFactory;
        private readonly IRegionalParcelRepository<ISingaporeRegion> _parcelRepository;

        public ParcelDomain(IRegionalFactory regionalFactory,IRegionalParcelRepository<ISingaporeRegion> parcelRepository)
        {
            _regionalFactory = regionalFactory;
            _parcelRepository = parcelRepository;
        }
        public void PushParcel(string parcelIformation)
        {
            throw new NotImplementedException();
        }

        public void CreateAndReservceParcel(string region)
        {
            throw new NotImplementedException();
        }

        public string GetFirstParcel(string region)
        {
            throw new NotImplementedException();
        }

        public bool PickupParcel(string region, string parcelData)
        {
            bool isSuccess = false;

            var parcel = _parcelRepository.GetParcelById(Guid.Empty);

            ParcelRepository a = null;




            return isSuccess;
        }
    }
}
