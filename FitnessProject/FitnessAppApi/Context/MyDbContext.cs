using FitnessAppApi.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppApi.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }
        public DbSet<FitnessArena> FitnessArenas { get; set; }
        public DbSet<TicketTypes> TicketTypes { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Entries> Entries { get; set; }
        public DbSet<ClientTickets> ClientTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=fitnessterem_db;user=root;password=1ddirectioner;", ServerVersion.AutoDetect("server=localhost;port=3306;database=fitnessterem_db;user=root;password=1ddirectioner;"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FitnessGymArenas
            modelBuilder.Entity<FitnessArena>()
                .ToTable("Arenas")
                .HasKey(a => a.ArenaId);

            modelBuilder.Entity<FitnessArena>()
                .Property(a => a.Name)
                .IsRequired();

            modelBuilder.Entity<FitnessArena>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(false);

            // TicketTypes
            modelBuilder.Entity<TicketTypes>()
                .ToTable("TicketTypes")
                .HasKey(t => t.TicketTypeId);

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.Name)
                .IsRequired();

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.Price)
                .IsRequired();

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.ValidityDays)
                .IsRequired();

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.ValidityEntries)
                .IsRequired();

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.ArenaId)
                .IsRequired();

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.StartHour)
                .IsRequired();

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.EndHour)
                .IsRequired();

            modelBuilder.Entity<TicketTypes>()
                .Property(t => t.EntriesPerDay)
                .IsRequired();

            // Clients
            modelBuilder.Entity<Clients>()
                .ToTable("Clients")
                .HasKey(c => c.ClientId);

            modelBuilder.Entity<Clients>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.Phone)
                .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.Email)
                .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Clients>()
                .Property(c => c.InsertedDate)
                .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.CNP)
                .IsRequired();

            modelBuilder.Entity<Clients>()
                .Property(c => c.Address)
                .IsRequired();

            // Entries
            modelBuilder.Entity<Entries>()
                .ToTable("Entries")
                .HasKey(e => e.EntryId);

            modelBuilder.Entity<Entries>()
                .Property(e => e.ClientId)
                .IsRequired();

            modelBuilder.Entity<Entries>()
                .Property(e => e.TicketTypeId)
                .IsRequired();

            modelBuilder.Entity<Entries>()
               .Property(e => e.Date)
               .IsRequired();

            modelBuilder.Entity<Entries>()
               .Property(e => e.InsertedByUid)
               .IsRequired();

            modelBuilder.Entity<Entries>()
               .Property(e => e.ArenaId)
               .IsRequired();

            // ClientTickets
            modelBuilder.Entity<ClientTickets>()
                .ToTable("ClientTickets")
                .HasKey(ct => ct.ClientTicketsId);

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.ClientId)
                .IsRequired();

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.TicketTypeId)
                .IsRequired();

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.IssueDate)
                .IsRequired();

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.NumOfEntries)
                .IsRequired();

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.BuyPrice)
                .IsRequired();

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.Valid)
                .IsRequired();

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.FirstUsageDate)
                .IsRequired();

            modelBuilder.Entity<ClientTickets>()
                .Property(ct => ct.ArenaId)
                .IsRequired();
        }
    }
}
