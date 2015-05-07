namespace Tz.Hongkong_ParcelPersistanceModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Tz.Common;
    using Tz.Region;

    public partial class ParcelDbContext_Hongkong : DbContext, IDataModelService<IHongkongRegion>
    {
        public ParcelDbContext_Hongkong(IConnectionString con)
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

        public string GetCountryRegion()
        {
            throw new NotImplementedException();
        }

        public new void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void ReleaseModel()
        {
            throw new NotImplementedException();
        }
    }
}
