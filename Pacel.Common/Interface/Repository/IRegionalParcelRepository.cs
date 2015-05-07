using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.ParcelDomainModel.Aggregate;
using Tz.Region;

namespace Tz.Parcel.Common.Interface.Repository
{
    public interface IRegionalParcelRepository<out T> where T :IRegionalConfiguration
    {
        ParcelDm GetParcelById(Guid parcelId);
        ParcelDm GetParcelByConsignmentNumber(string consignmentNumber);

        void SaveParcel(ParcelDm parcelInfor);
    }
}
