using Microsoft.EntityFrameworkCore;
using ClientAPI.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using static ClientAPI.API.Entities;

namespace ClientAPI.Context
{
    public class MyDBContext : DbContext
    {
        public DbSet<Fitness> Fitness { get; set; }
        public DbSet<Memberships> Memberships { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Entries> Entries { get; set; }
        public DbSet<ClientMemberships> ClientMemberships { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=fitnessterem_db;user=root;password=1ddirectioner;", ServerVersion.AutoDetect("server=localhost;port=3306;database=fitnessterem_db;user=root;password=1ddirectioner;"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fitness
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Fitness>()
                .ToTable("Fitnesses")
                .HasKey(f => f.fitnessID);

            modelBuilder.Entity<Fitness>()
                .Property(f => f.fitnessName)
                .IsRequired();

            modelBuilder.Entity<Fitness>()
                .Property(f => f.isDeleted)
                .HasDefaultValue(false);

            //memberships
            modelBuilder.Entity<Memberships>()
                .ToTable("Memberships")
                .HasKey(m => m.membershipID);

            modelBuilder.Entity<Memberships>()
                .Property(m => m.membershipName)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property(m => m.membershipPrice)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property(m => m.validityDays)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property(m => m.validityEntries)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property(m => m.isDeleted)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property (m => m.fitnessID)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property(m => m.fromHour)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property(m => m.toHour)
                .IsRequired();

            modelBuilder.Entity<Memberships>()
                .Property(m => m.dailyEntriesNumber)
                .IsRequired();

            //clients

            modelBuilder.Entity<Clients>()
                .ToTable("Clients")
                .HasKey(c => c.clientID);

            modelBuilder.Entity<Clients>()
                .Property(c => c.clientName) .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.phoneNumber) .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.email) .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.isDeleted) .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.registerDate) .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.CNP) .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.address) .IsRequired();

            //entries
            modelBuilder.Entity<Entries>()
                .ToTable("Entries")
                .HasKey(e => e.entriesID);
            modelBuilder.Entity<Entries>()
                .Property(e => e.clientID) .IsRequired();
            modelBuilder.Entity<Entries>()
                .Property(e => e.membershipID) .IsRequired();
            modelBuilder.Entity<Entries>()
                .Property(e => e.date) .IsRequired();
            modelBuilder.Entity<Entries>()
                .Property(e => e.insertedByUID) .IsRequired();
            modelBuilder.Entity<Entries>()
                .Property(e => e.fitnessID) .IsRequired();

            //client memberships
            modelBuilder.Entity<ClientMemberships>()
                .ToTable("ClientMemberships")
                .HasKey(cm => cm.clientMembershipID);

            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.clientID) .IsRequired();
            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.membershipID).IsRequired();
            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.buyingDate) .IsRequired();
            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.nrOfEntries) .IsRequired();
            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.price) .IsRequired();
            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.isValid) .IsRequired();
            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.firstUsage) .IsRequired();
            modelBuilder.Entity<ClientMemberships>()
                .Property(cm => cm.fitnessID) .IsRequired();

        }
    }
}
