using Parcel.Common.Interface;
using ParcelModel_Hongkong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace ParcelBusiness_Hongkong
{
    public class ParcelReservation_Hongkong : IParcelReservation<IHongkongRegion>
    {

        public bool CreateParcel()
        {
            IConnectionString con = new ConnectionStringConfiguration();
            ParcelDbContext_Hongkong db = new ParcelDbContext_Hongkong(con);

            ParcelModel_Hongkong.Parcel p = new ParcelModel_Hongkong.Parcel();
            p.Id = Guid.NewGuid();

            p.ConsignmentNo = "9876";
            p.OrgnizationId = Guid.Parse("37B54B16-F3D1-47CE-A8B4-4E8070EC694F");
            p.CreateUserId = Guid.NewGuid();
            p.CreationTime = DateTime.Now;
            p.UpdateUserId = Guid.NewGuid();
            p.LastUpdateTime = DateTime.Now;

            db.Parcels.Add(p);

            db.SaveChanges();
            return false;
        }


        public string GetFirstParcel()
        {
            IConnectionString con = new ConnectionStringConfiguration();
            ParcelDbContext_Hongkong db = new ParcelDbContext_Hongkong(con);
            var firstParcel = db.Parcels.Where(a=>a.ConsignmentNo=="9876").FirstOrDefault();
            if (firstParcel != null && firstParcel.ConsignmentNo == "9876")
            {
                return "Genetech";
            }

            return "Non-Genetech";
        }
    }
}
