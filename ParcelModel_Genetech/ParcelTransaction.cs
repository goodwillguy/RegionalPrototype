namespace ParcelModel_Hongkong
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ParcelTransaction")]
    public partial class ParcelTransaction
    {
        public ParcelTransaction()
        {
            AccessTokens = new HashSet<AccessToken>();
            ParcelReservations = new HashSet<ParcelReservation>();
            AccessTokens1 = new HashSet<AccessToken>();
        }

        public Guid Id { get; set; }

        public Guid? CreateUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreationTime { get; set; }

        public Guid UpdateUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastUpdateTime { get; set; }

        public Guid? KioskId { get; set; }

        public Guid ParcelId { get; set; }

        public Guid? DropOffUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DropOffTime { get; set; }

        public byte[] DropOffSignature { get; set; }

        public Guid? PickUpUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PickUpTime { get; set; }

        public byte[] PickUpSignature { get; set; }

        public int Purpose { get; set; }

        public int TransactionState { get; set; }

        public Guid? LocationReasonId { get; set; }

        public Guid? LocationId { get; set; }

        public Guid? LockerId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpiryTime { get; set; }

        public bool IsExpired { get; set; }

        [StringLength(50)]
        public string DropOffGovernmentId { get; set; }

        [StringLength(50)]
        public string PickUpGovernmentId { get; set; }

        [StringLength(50)]
        public string Discriminator { get; set; }

        public bool Is24ReminderHoursSent { get; set; }

        public bool Is48ReminderHoursSent { get; set; }

        public virtual ICollection<AccessToken> AccessTokens { get; set; }

        public virtual Parcel Parcel { get; set; }

        public virtual ICollection<ParcelReservation> ParcelReservations { get; set; }

        public virtual ICollection<AccessToken> AccessTokens1 { get; set; }
    }
}
