using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ParcelModule.Common.Arguments
{
    [DataContract]
    public class ParcelPickupArgs
    {
        public Guid ParcelStatusId;
    }
}
