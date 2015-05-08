using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace Tz.Parcel.Common.Interface
{
    [ServiceContract]
    public interface IParcelService
    {
        [OperationContract]
        void CreateAndReservceParcel(string region);

        [OperationContract]
        string GetFirstParcel(string region);

        [OperationContract]
        bool PickupParcel(string region, string parcelData);
    }
}
