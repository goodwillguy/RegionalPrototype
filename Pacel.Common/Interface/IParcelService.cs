using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace Tz.Parcel.Common.Interface
{
    public interface IParcelService
    {
        void SyncParcel(string parcelInformation);
        void PushParcel(string parcelIformation);
        bool PickupParcel(Guid parcelId, string parcelData);
    }
}
