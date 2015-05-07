using PacelModule.Arguments;
using ParcelModel_Genetech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;

namespace ParcelBusiness_Genetech.Commands
{
    public class SavePickupData : CommandBase<ParcelPickupArgs>
    {
        public override void Execute(ParcelPickupArgs args, IDataModelService dbContext)
        {
            var parcelDb = dbContext.GetDbSet<ParcelReservation>();

            var parcelTransaction=parcelDb.FirstOrDefault(reservation => reservation.Id == args.ParcelStatusId);

            parcelTransaction.UpdateUserId = Guid.NewGuid();
            parcelTransaction.LastUpdateTime = DateTime.Now;

            dbContext.SaveChanges();
        }
    }
}
