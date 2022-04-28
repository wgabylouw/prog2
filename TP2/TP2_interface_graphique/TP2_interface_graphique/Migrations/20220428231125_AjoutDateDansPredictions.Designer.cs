﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP2_interface_graphique;

namespace TP2_interface_graphique.Migrations
{
    [DbContext(typeof(TP2Context))]
    [Migration("20220428231125_AjoutDateDansPredictions")]
    partial class AjoutDateDansPredictions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TP2_interface_graphique.Models.Parameters", b =>
                {
                    b.Property<int>("ParametersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Algorithm")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("K")
                        .HasColumnType("int");

                    b.Property<string>("TrainPath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ParametersId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("TP2_interface_graphique.Models.Predictions", b =>
                {
                    b.Property<int>("PredictionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Alcohol")
                        .HasColumnType("float");

                    b.Property<float>("CitricAcid")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatePrediction")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ParametersId")
                        .HasColumnType("int");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<float>("Sulphates")
                        .HasColumnType("float");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<float>("VolatileAcidity")
                        .HasColumnType("float");

                    b.HasKey("PredictionsId");

                    b.HasIndex("ParametersId")
                        .IsUnique();

                    b.HasIndex("UsersId");

                    b.ToTable("Predictions");
                });

            modelBuilder.Entity("TP2_interface_graphique.Models.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Birthday")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TP2_interface_graphique.Models.Predictions", b =>
                {
                    b.HasOne("TP2_interface_graphique.Models.Parameters", "Parameters")
                        .WithOne("Predictions")
                        .HasForeignKey("TP2_interface_graphique.Models.Predictions", "ParametersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP2_interface_graphique.Models.Users", "Users")
                        .WithMany("Predictions")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
