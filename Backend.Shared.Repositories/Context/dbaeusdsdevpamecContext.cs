﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Backend.Shared.Entities.Models.Pamec;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Shared.Repositories.Context
{
    public partial class dbaeusdsdevpamecContext : DbContext
    {
        public dbaeusdsdevpamecContext()
        {
        }

        public dbaeusdsdevpamecContext(DbContextOptions<dbaeusdsdevpamecContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Entities.Models.Auttitulos.Resolutions> Resolutions { get; set; }
        public virtual DbSet<Entities.Models.Auttitulos.Title_types> Tittle_types { get; set; }
        public virtual DbSet<Entities.Models.Auttitulos.Status_types> Status_types { get; set; }
    
        public virtual DbSet<Entities.Models.Auttitulos.Entities> Entities { get; set; }
        public virtual DbSet<Entities.Models.Auttitulos.Documents_type> Documents_type { get; set; }

        public virtual DbSet<Entities.Models.Auttitulos.Document_types_procedure> Document_types_procedure { get; set; }


        public virtual DbSet<Constante> Constante { get; set; }
       
        public virtual DbSet<SeguimientoPAMEC> SeguimientoPAMEC { get; set; }
      
       
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Models.Auttitulos.Resolutions>(entity =>
            {

                entity.ToTable("resolutions", "auttitulos");
                entity.HasKey(e => e.IdResolution)
                       .HasName("PK__resoluti__532D927499E931EA");

                entity.Property(e => e.IdResolution).ValueGeneratedNever();

                entity.Property(e => e.date).HasColumnType("datetime");
                entity.Property(e => e.number)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdResProcNavigation)
               .WithMany(p => p.Resolutions)
               .HasForeignKey(d => d.IdProcedureRequest)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FKresolution767464");


            });
            modelBuilder.Entity< Entities.Models.Auttitulos.Title_types> (entity =>
            {
                entity.ToTable("title_types", "auttitulos");
                entity.HasKey(e => e.IdTitleType)
                       .HasName("PK__title_ty__DFCFB5D4E58694A3");
                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });
            modelBuilder.Entity<Entities.Models.Auttitulos.Status_types>(entity =>
            {
                entity.ToTable("status_types", "auttitulos");
                entity.HasKey(e => e.IdStatusType)
                       .HasName("PK__status_t__400FABBE3E41332A");
                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });
           
            modelBuilder.Entity<Entities.Models.Auttitulos.Entities>(entity =>
            {
                entity.ToTable("entities", "auttitulos");
                entity.HasKey(e => e.IdEntity)
                       .HasName("PK__entities__FE2B2B745C930AE6");
                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });
            modelBuilder.Entity<Entities.Models.Auttitulos.Documents_type>(entity =>
            {
                entity.ToTable("document_types", "auttitulos");
                entity.HasKey(e => e.IdDocumentType)
                       .HasName("PK__document__19CDAC3D56BB17A7");

                entity.Property(e => e.IdDocumentType).ValueGeneratedNever();


                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                
                 entity.HasOne(d => d.IdTitleTypeNavigation)
                  .WithMany(p => p.Documents_type)
                  .HasForeignKey(d => d.IdTitleType)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FKdocument_t336249");

                /*
                   entity.HasOne(d => d.IdTitleTypeNavigation)
                      .WithOne(p => p.Documents_type)
                      .HasForeignKey<Entities.Models.Auttitulos.Documents_type>(d => d.IdDocumenType)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FKdocument_t336249");
                */
            });
            modelBuilder.Entity<Entities.Models.Auttitulos.Document_types_procedure>(entity =>
            {
                entity.ToTable("document_types_procedure_requests", "auttitulos");
                entity.HasKey(e => e.IdDocumentTypeProcedureRequest)
                       .HasName("PK__document__C4EDD5541BF4D9E1");

                entity.Property(e => e.IdDocumentTypeProcedureRequest).ValueGeneratedNever();


                entity.Property(e => e.path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.modification_date).HasColumnType("datetime");
                entity.Property(e => e.registration_date).HasColumnType("datetime");

                /*

                entity.HasOne(d => d.IdTitleTypeNavigation)
                 .WithMany(p => p.Documents_type)
                 .HasForeignKey(d => d.IdTitleType)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FKdocument_t336249");

                
                
                   entity.HasOne(d => d.IdTitleTypeNavigation)
                      .WithOne(p => p.Documents_type)
                      .HasForeignKey<Entities.Models.Auttitulos.Documents_type>(d => d.IdDocumenType)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FKdocument_t336249");




                 entity.HasOne(d => d.IdDocumentProcNavigation)
                  .WithOne(p => p.Document_types_procedure)
                  .HasForeignKey<Entities.Models.Auttitulos.Document_types_procedure>(d => d.IdDocumentTypeProcedureRequest)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FKdocument_t365876");

                entity.HasOne(d => d.IdProcdocNavigation)
                  .WithOne(p => p.Document_types_procedure)
                  .HasForeignKey<Entities.Models.Auttitulos.Document_types_procedure>(d => d.IdDocumentTypeProcedureRequest)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FKdocument_t810282");





                */

                entity.HasOne(d => d.IdDocumentProcNavigation)
                 .WithMany(p => p.Document_types_procedure)
                 .HasForeignKey(d => d.IdDocumentType)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FKdocument_t365876");

                entity.HasOne(d => d.IdProcdocNavigation)
                 .WithMany(p => p.Document_types_procedure)
                 .HasForeignKey(d => d.IdProcedureRequest)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FKdocument_t810282");


               

            });

            modelBuilder.Entity<Entities.Models.Auttitulos.procedure_requests>(entity =>
            {
                entity.ToTable("procedure_requests", "auttitulos");
                entity.HasKey(e => e.IdProcedureRequest)
                       .HasName("PK__procedur__C2E3D66575ABAA75");

                entity.Property(e => e.IdProcedureRequest).ValueGeneratedNever();

                entity.Property(e => e.end_date).HasColumnType("datetime");
                entity.Property(e => e.date_resolution_convalidation).HasColumnType("datetime");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.user_code_ventanilla)
                   .IsRequired()
                   .HasMaxLength(9)
                   .IsUnicode(false);

                entity.Property(e => e.filed_number)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.IdProfession)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsUnicode(false);

                entity.Property(e => e.year_title)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsUnicode(false);

                entity.HasOne(d => d.IdTitleTypeprocNavigation)
                 .WithMany(p => p.procedure_requests)
                 .HasForeignKey(d => d.IdTitleTypes)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FKprocedure_36170");

                entity.HasOne(d => d.IdStatusTypeprocNavigation)
                .WithMany(p => p.procedure_requests)
                .HasForeignKey(d => d.IdStatus_types)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKprocedure_665708");

                /*
                   entity.HasOne(d => d.IdTitleTypeNavigation)
                      .WithOne(p => p.Documents_type)
                      .HasForeignKey<Entities.Models.Auttitulos.Documents_type>(d => d.IdDocumenType)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FKdocument_t336249");
                */
            });


                      
           

           
            modelBuilder.Entity<Entities.Models.Auttitulos.Tracking>(entity =>
            {
                entity.ToTable("tracking", "auttitulos");
                entity.HasKey(e => e.IdTracking)
                       .HasName("PK__tracking__FDC1E65CB18FC28F");

                entity.Property(e => e.IdTracking).ValueGeneratedNever();

                entity.Property(e => e.date_tracking).HasColumnType("datetime");               

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                

                entity.HasOne(d => d.IdStatusTypeTracNavigation)
                 .WithMany(p => p.Tracking)
                 .HasForeignKey(d => d.IdStatusTypes)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FKprocedure_36170");

                entity.HasOne(d => d.IdTrackProcNavigation)
                .WithMany(p => p.Tracking)
                .HasForeignKey(d => d.IdProcedureRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKprocedure_665708");



            });

         

           
           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}