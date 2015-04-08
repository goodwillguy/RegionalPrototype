using Pacel.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.ParcelModel_Singapore;

namespace ParcelBusiness_Singapore
{
    public class ParcelReservation:IParcelReservation
    {

        public bool CreateParcel()
        {
            IConnectionString con = new ConnectionStringConfiguration();
            ParcelDbContext_Singapore db = new ParcelDbContext_Singapore(con);

            Parcel p = new Parcel();
            p.Id = Guid.NewGuid();

            p.ParcelId = Guid.NewGuid().ToString();
            p.OrderNumber = "1234";

            db.Parcels.Add(p);

            db.SaveChanges();
            return false;
        }


        public string GetFirstParcel()
        {
            IConnectionString con = new ConnectionStringConfiguration();
            ParcelDbContext_Singapore db = new ParcelDbContext_Singapore(con);
            var firstParcel=db.Parcels.FirstOrDefault();
            if(firstParcel!=null && firstParcel.OrderNumber=="1234")
            {
                return "Singapore";
            }

            return "Non-Singapore";
        }
    }
}
