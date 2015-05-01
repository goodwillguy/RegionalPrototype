using PacelModule.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;

namespace ParcelBusiness_Genetech.Commands
{
    public class GetUserInformation : CommandBase<ParcelPickupArgs>
    {

        public override void Execute(ParcelPickupArgs args, IDataModelService dbContext)
        {
        }
    }
}
