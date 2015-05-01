using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace Parcel.Common.Interface
{
    public interface IParcelDomain<T> where T: IRegionalConfiguration
    {
        bool PickupParcel(Guid parcelId, string parcelData);
    }
}
