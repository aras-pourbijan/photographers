using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace photographers.Models
{
    public partial class ModelDBcontext : DbContext
    {
        public ModelDBcontext()
            : base("name=photoDB")
        {
        }

        public virtual DbSet<detailReservation> detailReservations { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<portfolio> portfolios { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<location>()
                .HasMany(e => e.reservations)
                .WithRequired(e => e.location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<Photographer>()
                .HasMany(e => e.detailReservations)
                .WithRequired(e => e.Photographer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<portfolio>()
                .HasMany(e => e.Photographers)
                .WithOptional(e => e.portfolio)
                .HasForeignKey(e => e.IDportafolio);

            modelBuilder.Entity<reservation>()
                .Property(e => e.customerTel)
                .IsUnicode(false);

            modelBuilder.Entity<reservation>()
                .Property(e => e.customerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<reservation>()
                .HasMany(e => e.detailReservations)
                .WithRequired(e => e.reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slot>()
                .HasMany(e => e.reservations)
                .WithRequired(e => e.Slot)
                .WillCascadeOnDelete(false);
        }
    }
}
