using System;
using System.Collections.Generic;
using Mbbs2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mbbs2.Data;

public partial class DhsMagacousesContext : IdentityDbContext
{
    public DhsMagacousesContext()
    {
    }

    public DhsMagacousesContext(DbContextOptions<DhsMagacousesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeEligibilityCriterion> AgeEligibilityCriteria { get; set; }

    public virtual DbSet<ApplicantsAlliedCourse> ApplicantsAlliedCourses { get; set; }

    public virtual DbSet<ApplicantsAnm> ApplicantsAnms { get; set; }

    public virtual DbSet<ApplicantsGnm> ApplicantsGnms { get; set; }

    public virtual DbSet<ApplicantsMbb> ApplicantsMbbs { get; set; }

    public virtual DbSet<MApplicationStatus> MApplicationStatuses { get; set; }

    public virtual DbSet<MApplicationType> MApplicationTypes { get; set; }

    public virtual DbSet<MBlock> MBlocks { get; set; }

    public virtual DbSet<MCategory> MCategories { get; set; }

    public virtual DbSet<MCoursesAlliedCourse> MCoursesAlliedCourses { get; set; }

    public virtual DbSet<MCoursesAnm> MCoursesAnms { get; set; }

    public virtual DbSet<MCoursesGnm> MCoursesGnms { get; set; }

    public virtual DbSet<MCoursesMbb> MCoursesMbbs { get; set; }

    public virtual DbSet<MDistrict> MDistricts { get; set; }

    public virtual DbSet<MGender> MGenders { get; set; }

    public virtual DbSet<MNationality> MNationalities { get; set; }

    public virtual DbSet<MReligion> MReligions { get; set; }

    public virtual DbSet<MScreeningCentre> MScreeningCentres { get; set; }

    public virtual DbSet<MState> MStates { get; set; }

    public virtual DbSet<MUser> MUsers { get; set; }

    public virtual DbSet<MVillage> MVillages { get; set; }

    public virtual DbSet<PreferenceAlliedCourse> PreferenceAlliedCourses { get; set; }

    public virtual DbSet<PreferenceMbb> PreferenceMbbs { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicantsAlliedCourse>(entity =>
        {
            entity.Property(e => e.ApplicantId).ValueGeneratedNever();
            entity.Property(e => e.EMail).IsFixedLength();
            entity.Property(e => e.Mobile).IsFixedLength();
        });

        modelBuilder.Entity<ApplicantsAnm>(entity =>
        {
            entity.Property(e => e.EMail).IsFixedLength();
            entity.Property(e => e.Mobile).IsFixedLength();
            entity.Property(e => e.Stream).IsFixedLength();
        });

        modelBuilder.Entity<ApplicantsGnm>(entity =>
        {
            entity.Property(e => e.EMail).IsFixedLength();
            entity.Property(e => e.Mobile).IsFixedLength();
            entity.Property(e => e.Stream).IsFixedLength();
        });

        modelBuilder.Entity<ApplicantsMbb>(entity =>
        {
            entity.Property(e => e.EMail).IsFixedLength();
            entity.Property(e => e.Gender).IsFixedLength();
            entity.Property(e => e.Mobile).IsFixedLength();
        });

        modelBuilder.Entity<MApplicationStatus>(entity =>
        {
            entity.Property(e => e.ApplicationStatus).ValueGeneratedNever();
            entity.Property(e => e.ApplicationStatusDesc).IsFixedLength();
        });

        modelBuilder.Entity<MApplicationType>(entity =>
        {
            entity.Property(e => e.ApplicationDesc).IsFixedLength();
        });

        modelBuilder.Entity<MBlock>(entity =>
        {
            entity.Property(e => e.BlockCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<MCategory>(entity =>
        {
            entity.Property(e => e.CategoryDesc).IsFixedLength();
        });

        modelBuilder.Entity<MCoursesAlliedCourse>(entity =>
        {
            entity.Property(e => e.AcCourseName).IsFixedLength();
        });

        modelBuilder.Entity<MCoursesAnm>(entity =>
        {
            entity.Property(e => e.AmnCourse).IsFixedLength();
        });

        modelBuilder.Entity<MCoursesGnm>(entity =>
        {
            entity.Property(e => e.GmnCouse).IsFixedLength();
        });

        modelBuilder.Entity<MCoursesMbb>(entity =>
        {
            entity.Property(e => e.MbbsCouseName).IsFixedLength();
        });

        modelBuilder.Entity<MDistrict>(entity =>
        {
            entity.HasKey(e => e.DistrictCode).HasName("PK_mDistricts_1");

            entity.Property(e => e.DistrictCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<MGender>(entity =>
        {
            entity.Property(e => e.Gender).IsFixedLength();
            entity.Property(e => e.GenderDesc).IsFixedLength();
        });

        modelBuilder.Entity<MReligion>(entity =>
        {
            entity.Property(e => e.Religion).ValueGeneratedNever();
            entity.Property(e => e.ReligionDesc).IsFixedLength();
        });

        modelBuilder.Entity<MState>(entity =>
        {
            entity.Property(e => e.StateCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<MUser>(entity =>
        {
            entity.Property(e => e.UserCategory).IsFixedLength();
            entity.Property(e => e.UserMobile).IsFixedLength();
        });

        modelBuilder.Entity<MVillage>(entity =>
        {
            entity.HasKey(e => e.VillageCode).HasName("PK_mVillages_1");

            entity.Property(e => e.VillageCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.Property(e => e.AcademicSession).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
