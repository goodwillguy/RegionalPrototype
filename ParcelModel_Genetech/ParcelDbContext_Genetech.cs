namespace ParcelModel_Genetech
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Tz.Common;

    public partial class ParcelDbContext_Genetech : DbContext
    {
        public ParcelDbContext_Genetech(IConnectionString con)
            : base(con.ConnectionString("Genetech"))
        {
        }

        public virtual DbSet<AccessToken> AccessTokens { get; set; }
        public virtual DbSet<Parcel> Parcels { get; set; }
        public virtual DbSet<ParcelReservation> ParcelReservations { get; set; }
        public virtual DbSet<ParcelTransaction> ParcelTransactions { get; set; }
        public virtual DbSet<KioskView> KioskViews { get; set; }
        public virtual DbSet<LockerView> LockerViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessToken>()
                .HasMany(e => e.ParcelTransactions)
                .WithMany(e => e.AccessTokens1)
                .Map(m => m.ToTable("AccessTokenParcelTransaction").MapLeftKey("AccessTokenId").MapRightKey("ParcelTransactionId"));

            modelBuilder.Entity<Parcel>()
                .HasMany(e => e.ParcelTransactions)
                .WithRequired(e => e.Parcel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParcelTransaction>()
                .HasMany(e => e.AccessTokens)
                .WithOptional(e => e.ParcelTransaction)
                .HasForeignKey(e => e.ParcelTransactionId);

            modelBuilder.Entity<ParcelTransaction>()
                .HasMany(e => e.ParcelReservations)
                .WithOptional(e => e.ParcelTransaction)
                .HasForeignKey(e => e.TransactionId);
        }
    }
}
