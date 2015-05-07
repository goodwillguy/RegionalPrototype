namespace Tz.Hongkong_ParcelPersistanceModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ParcelReservation")]
    public partial class ParcelReservation
    {
        public Guid Id { get; set; }

        public Guid CreateUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        public Guid UpdateUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastUpdateTime { get; set; }

        public Guid KioskId { get; set; }

        public Guid? TransactionId { get; set; }

        public int State { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ExpiryTime { get; set; }

        public Guid? LockerId { get; set; }

        public int? LockerSize { get; set; }

        public string CustomData { get; set; }

        public virtual ParcelTransaction ParcelTransaction { get; set; }
    }
}
