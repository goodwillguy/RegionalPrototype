using Tz.ParcelDomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.ParcelDomainModel.Aggregate
{
    public class ParcelTransactionDm
    {
        private Guid? nullable;
        private Guid guid;

        public Guid ParcelTransactionId { get; private set; }

        public Guid?  KioskId { get; set; }
                    
        public Guid?  ParcelId { get; private set; }
                    
        public int? State { get; set; }

        public Guid? DropoffUserId { get; set; }

        public PickupKeyDm[] PickupKeys { get; set; }

        public Guid? LocationReasonId { get; set; }
        public ParcelTransactionDm(Guid? parcelId,Guid parcelTransactionId)
        {
            this.ParcelTransactionId = parcelTransactionId;
            this.ParcelId = parcelId.GetValueOrDefault();
        }

        public ParcelTransactionDm()
        {
            // TODO: Complete member initialization
        }


    }
}
