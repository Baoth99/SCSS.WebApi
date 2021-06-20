﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SCSS.Data.Entities;
using SCSS.Utilities.AuthSessionConfig;
using SCSS.Utilities.Constants;
using System;
using System.Linq.Expressions;
using System.Reflection;


namespace SCSS.Data.EF
{
    public class AppDbContext : DbContext
    {
        #region Constructor

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #endregion

        #region DbSet

        // Add Dbset here
        public DbSet<Account> Account { get; set; }

        public DbSet<AccountCategory> MyProperty { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<CategoryAdmin> CategoryAdmin { get; set; }

        public DbSet<CollectDealTransaction> CollectDealTransaction { get; set; }

        public DbSet<CollectDealTransactionDetail> CollectDealTransactionDetail { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<ItemType> ItemType { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Notification> Notification { get; set; }

        public DbSet<Promotion> Promotion { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<SellCollectTransaction> SellCollectTransaction { get; set; }

        public DbSet<SellCollectTransactionDetail> SellCollectTransactionDetail { get; set; }

        public DbSet<ServiceTransaction> ServiceTransaction { get; set; }

        public DbSet<Unit> Unit { get; set; }

        #endregion

        #region OnConfiguring

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionString", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Entities Config

            modelBuilder.Entity<Account>(entity =>
            {

            });

            modelBuilder.Entity<AccountCategory>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
                entity.Property(e => e.CollectorAccountId).IsConcurrencyToken();
            });

            modelBuilder.Entity<CategoryAdmin>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<CollectDealTransaction>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<CollectDealTransactionDetail>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<SellCollectTransaction>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<SellCollectTransactionDetail>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<ServiceTransaction>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");
            });

            #endregion


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IHasSoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();

                }
            }
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Before SaveChanges

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = BooleanConstants.FALSE;
                        entry.CurrentValues["CreatedTime"] = DateTime.Now;
                        entry.CurrentValues["CreatedBy"] = AuthSessionGlobalVariable.UserSession.Id;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = BooleanConstants.TRUE;
                        break;

                    case EntityState.Modified:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["UpdatedTime"] = DateTime.Now;
                        entry.CurrentValues["UpdatedBy"] = AuthSessionGlobalVariable.UserSession.Id; // Custom
                        break;
                }
            }
        }

        #endregion

    }

    #region HasSoftDelete Config

    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension).GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);

            var filter = methodToCall.Invoke(null, new object[] { });

            entityData.SetQueryFilter((LambdaExpression)filter);

            entityData.AddIndex(entityData.
                 FindProperty(nameof(IHasSoftDelete.IsDeleted)));
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, IHasSoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }

    #endregion
}

