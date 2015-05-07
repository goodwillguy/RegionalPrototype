using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.ParcelDomainModel.Model
{
    public class PickupKeyDm
    {
        public Guid Id { get; set; }

        public bool? IsExpired { get; set; }
    }
}
