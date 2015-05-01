using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace Parcel.Common.Interface
{
    public interface IParcelReservation<T> where T : IRegionalConfiguration
    {
        bool CreateParcel();
        string GetFirstParcel();
    }
}
