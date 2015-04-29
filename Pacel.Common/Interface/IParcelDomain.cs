using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacel.Common.Interface
{
    public interface IParcelDomain
    {
        bool PickupParcel(Guid parcelId, string parcelData);
    }
}
