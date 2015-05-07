using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PacelModule.Arguments
{
    [DataContract]
    public class ParcelPickupArgs
    {
        public Guid ParcelStatusId;
    }
}
