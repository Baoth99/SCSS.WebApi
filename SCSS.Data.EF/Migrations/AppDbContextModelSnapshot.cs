﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCSS.Data.EF;

namespace SCSS.Data.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCSS.Data.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceId")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdCard")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<Guid?>("ManagedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<float?>("TotalPoint")
                        .HasColumnType("real");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("[Phone] IS NOT NULL");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("SCSS.Data.Entities.CollectDealTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("AwardPoint")
                        .HasColumnType("real");

                    b.Property<long?>("BonusAmount")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CollectorAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DealerAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("Total")
                        .HasColumnType("bigint");

                    b.Property<string>("TransactionCode")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<long?>("TransactionServiceFee")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("CollectDealTransaction");
                });

            modelBuilder.Entity("SCSS.Data.Entities.CollectDealTransactionDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("BonusAmount")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CollectDealTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DealerCategoryDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("PromotionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Quantity")
                        .HasColumnType("real");

                    b.Property<long?>("Total")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("CollectDealTransactionDetail");
                });

            modelBuilder.Entity("SCSS.Data.Entities.CollectingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ApprovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CancelReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectingRequestCode")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("CollectingRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CollectorAccountId")
                        .IsConcurrencyToken()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBulky")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScrapImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SellerAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Status")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TimeFrom")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("TimeTo")
                        .HasColumnType("time");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("CollectingRequest");
                });

            modelBuilder.Entity("SCSS.Data.Entities.CollectingRequestConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CancelTimeRange")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxNumberOfRequestDays")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("OperatingTimeFrom")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("OperatingTimeTo")
                        .HasColumnType("time");

                    b.Property<int>("ReceiveQuantity")
                        .HasColumnType("int");

                    b.Property<int>("RequestQuantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("CollectingRequestConfig");
                });

            modelBuilder.Entity("SCSS.Data.Entities.CollectingRequestRejection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollectingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("CollectingRequestRejection");
                });

            modelBuilder.Entity("SCSS.Data.Entities.DealerInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("CloseTime")
                        .HasColumnType("time");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DealerAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DealerImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealerName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DealerPhone")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubcribed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("OpenTime")
                        .HasColumnType("time");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DealerPhone")
                        .IsUnique()
                        .HasFilter("[DealerPhone] IS NOT NULL");

                    b.HasIndex("IsDeleted");

                    b.ToTable("DealerInformation");
                });

            modelBuilder.Entity("SCSS.Data.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminReply")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid?>("BuyingAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollectDealTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float?>("Rate")
                        .HasColumnType("real");

                    b.Property<Guid?>("SellCollectTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SellingAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SellingFeedback")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SellingReview")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("SCSS.Data.Entities.ImageSlider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("ImageSlider");
                });

            modelBuilder.Entity("SCSS.Data.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AddressName")
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(8,6)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(9,6)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("SCSS.Data.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DataCustom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("NotiType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("SCSS.Data.Entities.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("AppliedAmount")
                        .HasColumnType("bigint");

                    b.Property<long?>("BonusAmount")
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DealerAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DealerCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FromTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ToTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("SCSS.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SCSS.Data.Entities.ScrapCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ScrapCategory");
                });

            modelBuilder.Entity("SCSS.Data.Entities.ScrapCategoryDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("ScrapCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ScrapCategoryDetail");
                });

            modelBuilder.Entity("SCSS.Data.Entities.SellCollectTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AwardPoint")
                        .HasColumnType("int");

                    b.Property<Guid?>("CollectingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("Total")
                        .HasColumnType("bigint");

                    b.Property<long?>("TransactionServiceFee")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("SellCollectTransaction");
                });

            modelBuilder.Entity("SCSS.Data.Entities.SellCollectTransactionDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollectorCategoryDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.Property<float?>("Quantity")
                        .HasColumnType("real");

                    b.Property<Guid?>("SellCollectTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("Total")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("SellCollectTransactionDetail");
                });

            modelBuilder.Entity("SCSS.Data.Entities.ServiceTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("Amount")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CollectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Period")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("ServiceTransaction");
                });

            modelBuilder.Entity("SCSS.Data.Entities.TransactionAwardAmount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Amount")
                        .HasColumnType("real");

                    b.Property<long?>("AppliedAmount")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("TransactionType")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TransactionAwardAmount");
                });

            modelBuilder.Entity("SCSS.Data.Entities.TransactionServiceFeePercent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<float?>("Percent")
                        .HasColumnType("real");

                    b.Property<int?>("TransactionType")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TransactionServiceFeePercent");
                });
#pragma warning restore 612, 618
        }
    }
}
