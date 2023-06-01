using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TenderManagementSytem.Models
{
    public partial class TenderManagementContext : DbContext
    {
        

        public TenderManagementContext(DbContextOptions<TenderManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TenderMaster> TenderMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenderMaster>(entity =>
            {
                entity.HasKey(e => e.TenderId)
                    .HasName("PK__TenderMa__B21B42689FDF7BD3");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Details)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastSubmissionDate)
                    .HasColumnName("Last_Submission_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Organization)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenderAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TenderTitle)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
