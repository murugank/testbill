// <auto-generated />
using System;
using BillingApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BillingApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201220145433_AddedAppsRate")]
    partial class AddedAppsRate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("BillingApi.Model.App", b =>
                {
                    b.Property<int>("AppId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AppCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedon")
                        .HasColumnType("datetime2");

                    b.HasKey("AppId");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("BillingApi.Model.AppsRate", b =>
                {
                    b.Property<int>("AppsRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("AppGst")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<decimal>("AppRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedon")
                        .HasColumnType("datetime2");

                    b.Property<int>("RangeFrom")
                        .HasColumnType("int");

                    b.Property<int>("RangeTo")
                        .HasColumnType("int");

                    b.HasKey("AppsRateId");

                    b.HasIndex("AppId");

                    b.ToTable("AppsRates");
                });

            modelBuilder.Entity("BillingApi.Model.BaseCurrency", b =>
                {
                    b.Property<int>("BaseCurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BaseCurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedon")
                        .HasColumnType("datetime2");

                    b.HasKey("BaseCurrencyId");

                    b.ToTable("BaseCurrencys");
                });

            modelBuilder.Entity("BillingApi.Model.BillingandDueDay", b =>
                {
                    b.Property<int>("BillingandDueDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BillingDay")
                        .HasColumnType("int");

                    b.Property<int>("BillingDueDay")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedon")
                        .HasColumnType("datetime2");

                    b.HasKey("BillingandDueDayId");

                    b.ToTable("BillingandDueDays");
                });

            modelBuilder.Entity("BillingApi.Model.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CharacterType")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedon")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("BillingApi.Model.CurrencyRate", b =>
                {
                    b.Property<int>("CurrencyRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyRateCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrencyValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedon")
                        .HasColumnType("datetime2");

                    b.HasKey("CurrencyRateId");

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("BillingApi.Model.PlatformPrice", b =>
                {
                    b.Property<int>("PlatformPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GstPlatformRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedon")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PlatformRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlatformPriceId");

                    b.ToTable("PlatformPrices");
                });

            modelBuilder.Entity("BillingApi.Model.AppsRate", b =>
                {
                    b.HasOne("BillingApi.Model.App", "App")
                        .WithMany()
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("App");
                });
#pragma warning restore 612, 618
        }
    }
}
