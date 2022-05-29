﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIInventory.Data;

#nullable disable

namespace WebAPIInventory.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPIInventory.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Usable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Items", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("WebAPIInventory.StatsClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Attack")
                        .HasColumnType("float");

                    b.Property<double>("Block")
                        .HasColumnType("float");

                    b.Property<double>("Defense")
                        .HasColumnType("float");

                    b.Property<int>("EquipId")
                        .HasColumnType("int");

                    b.Property<double>("Evade")
                        .HasColumnType("float");

                    b.Property<double>("MagicAttack")
                        .HasColumnType("float");

                    b.Property<double>("MagicDefense")
                        .HasColumnType("float");

                    b.Property<double>("Resistance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EquipId")
                        .IsUnique();

                    b.ToTable("Stats", (string)null);
                });

            modelBuilder.Entity("WebAPIInventory.Equip", b =>
                {
                    b.HasBaseType("WebAPIInventory.Item");

                    b.Property<bool>("Enchanted")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Equip");
                });

            modelBuilder.Entity("WebAPIInventory.Weapon", b =>
                {
                    b.HasBaseType("WebAPIInventory.Equip");

                    b.Property<bool>("Ammunition")
                        .HasColumnType("bit");

                    b.Property<string>("TypeAttack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeWeapon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("WebAPIInventory.StatsClass", b =>
                {
                    b.HasOne("WebAPIInventory.Equip", null)
                        .WithOne("Stats")
                        .HasForeignKey("WebAPIInventory.StatsClass", "EquipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPIInventory.Equip", b =>
                {
                    b.Navigation("Stats")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
