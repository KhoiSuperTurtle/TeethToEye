using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeethToEyeAPI.Models;

namespace TeethToEyeAPI.Models;

public partial class TeethToEyeContext : DbContext
{
    public TeethToEyeContext()
    {
    }

    public TeethToEyeContext(DbContextOptions<TeethToEyeContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataType>(entity =>
        {
            entity.HasKey(e => e.DataTypeName);

            entity.ToTable("DataType");

            entity.Property(e => e.DataTypeName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataTypeName");
        });

        modelBuilder.Entity<SaveRecord>(entity =>
        {
            entity.HasKey(e => e.IdSaveRecord);

            entity.ToTable("SaveRecord");

            entity.Property(e => e.IdSaveRecord).HasColumnName("ID_SaveRecord");
            entity.Property(e => e.BinData)
                .HasMaxLength(1)
                .HasColumnName("binData");
            entity.Property(e => e.SaveRecordDataType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SaveRecord_DataType");
            entity.Property(e => e.Slotfile).HasColumnName("slotfile");
            entity.Property(e => e.Uid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UID");

            
        });

        modelBuilder.Entity<Uid>(entity =>
        {
            entity.HasKey(e => e.Uid1);

            entity.ToTable("UIDs");

            entity.Property(e => e.Uid1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<TeethToEyeAPI.Models.DataType>? DataType { get; set; }

    public DbSet<TeethToEyeAPI.Models.SaveRecord>? SaveRecord { get; set; }

    public DbSet<TeethToEyeAPI.Models.Uid>? Uid { get; set; }
}
