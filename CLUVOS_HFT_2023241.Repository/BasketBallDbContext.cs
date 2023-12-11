using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using CLUVOS_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore.InMemory;

namespace CLUVOS_HFT_2023241.Repository
{
    public class BasketBallDbContext : DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }  
        public DbSet<Player> Players { get; set; }
        public BasketBallDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("fbdb").UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne(x => x.League)
                .WithMany(x => x.Teams)
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            var leagues = new List<League>()
            {
                new League() { Id = 1, Country = "USA", Name = "NBA", HasVar = true },
                new League() { Id = 2, Country = "USA", Name = "WNBA", HasVar = false },
                new League() { Id = 3, Country = "Europe", Name = "EuroLeague", HasVar = true }
            };
            modelBuilder.Entity<League>().HasData(leagues);

            var teams = new List<Team>()
            {
                new Team(){Id=1, LeagueId = 1, Name = "Los Angeles Lakers", HasYoungLeagueTeam= true},
                new Team(){Id=2, LeagueId = 1, Name = "Golden State Warriors",HasYoungLeagueTeam= true},
                new Team(){Id=3, LeagueId = 2, Name = "Boston Celtics",HasYoungLeagueTeam= false},
                new Team(){Id=4, LeagueId = 1, Name = "Toronto Raptors",HasYoungLeagueTeam= true},
                new Team(){Id=5, LeagueId = 3, Name = "Bayern Munich",HasYoungLeagueTeam= false}

            };
            modelBuilder.Entity<Team>().HasData(teams);

            var players = new List<Player>()
            {
                new Player(){Id=1, Name = "Weiler-Babb, Nick", Age = 27, Position = "Point Guard", Salary = 1200000, TeamId =5},
                new Player(){Id=2, Name = "Lebron James", Age = 27, Position = "Power Forward", Salary = 2500000, TeamId =1},
                new Player(){Id=3, Name = "Stephen Curry", Age = 35, Position = "Point Guard", Salary = 1550000, TeamId =2},
                new Player(){Id=4, Name = "Jayson Tatum", Age = 25, Position = "Small Forward", Salary = 1000000, TeamId =3},
                new Player(){Id=5, Name = "Scottie Barnes", Age = 22, Position = "Small Forward", Salary = 1100000, TeamId =4}
            };
            modelBuilder.Entity<Player>().HasData(players);
        }
    }
}
