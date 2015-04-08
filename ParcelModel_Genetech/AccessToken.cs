namespace ParcelModel_Genetech
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessToken")]
    public partial class AccessToken
    {
        public AccessToken()
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

        public Guid? ParcelTransactionId { get; set; }

        public Guid? Credential { get; set; }

        [StringLength(50)]
        public string ManualCredential { get; set; }

        [StringLength(50)]
        public string Pin { get; set; }

        public int Operation { get; set; }

        public Guid UserId { get; set; }

        public virtual ParcelTransaction ParcelTransaction { get; set; }

        public virtual ICollection<ParcelTransaction> ParcelTransactions { get; set; }
    }
}
