using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.ParcelDomainModel.Aggregate
{
    public class ParcelDm
    {
        public Guid ParcelId { get; private set; }

        public string ConsignmentNumber { get; private set; }

        public Guid? SenderId { get; set; }

        public Guid? RecipientId { get; set; }

        public ParcelDm(Guid parcelId, string parcelConsignmentNo)
        {
            if (parcelId == Guid.Empty)
            {
                parcelId = Guid.NewGuid();
            }
            else
            {
                this.ParcelId = parcelId;
            }

            ConsignmentNumber = parcelConsignmentNo;
        }

        public ParcelTransactionDm[] ParcelTransactions { get; set; }

        public void UpdateSenderInformation(Guid senderId)
        {
            this.SenderId = senderId;
        }
    }
}
