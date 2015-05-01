namespace ParcelModel_Hongkong
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parcel")]
    public partial class Parcel
    {
        public Parcel()
        {
            ParcelTransactions = new HashSet<ParcelTransaction>();
        }

        public Guid Id { get; set; }

        public Guid CreateUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        public Guid UpdateUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastUpdateTime { get; set; }

        public Guid OrgnizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsignmentNo { get; set; }

        public Guid? SenderId { get; set; }

        public Guid? RecipientId { get; set; }

        public virtual ICollection<ParcelTransaction> ParcelTransactions { get; set; }
    }
}
