﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackerAPI.Data;

#nullable disable

namespace TrackerAPI.Migrations
{
    [DbContext(typeof(ExerciseContext))]
    [Migration("20220325095847_dateFormattedSeedData")]
    partial class dateFormattedSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrackerAPI.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            ExerciseId = 1,
                            Name = "Squat"
                        },
                        new
                        {
                            ExerciseId = 2,
                            Name = "Bench"
                        });
                });

            modelBuilder.Entity("TrackerAPI.Models.LiftingStat", b =>
                {
                    b.Property<int>("LiftingStatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LiftingStatId"), 1L, 1);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("LiftingStatId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("LiftingStats");

                    b.HasData(
                        new
                        {
                            LiftingStatId = 1,
                            Date = "25/03/2022",
                            ExerciseId = 1,
                            Repetitions = 5,
                            Weight = 100.0
                        },
                        new
                        {
                            LiftingStatId = 2,
                            Date = "25/03/2022",
                            ExerciseId = 1,
                            Repetitions = 5,
                            Weight = 105.0
                        },
                        new
                        {
                            LiftingStatId = 3,
                            Date = "25/03/2022",
                            ExerciseId = 2,
                            Repetitions = 5,
                            Weight = 85.5
                        });
                });

            modelBuilder.Entity("TrackerAPI.Models.LiftingStat", b =>
                {
                    b.HasOne("TrackerAPI.Models.Exercise", null)
                        .WithMany("Stats")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackerAPI.Models.Exercise", b =>
                {
                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
