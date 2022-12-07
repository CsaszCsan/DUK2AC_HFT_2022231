using Microsoft.EntityFrameworkCore;
using DUK2AC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Repositroy
{
    class GameShopDbContext:DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        public GameShopDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("GameShop");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity => 
            {
                    entity.HasOne(game => game.Developer) // One developer can have multiple games made
                    .WithMany(developer => developer.GamesMade) 
                    .HasForeignKey(game => game.DevID) 
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(achi => achi.game) // One Game can have multiple achievements here: achi for short
                .WithMany(Game => Game.Achievements) 
                .HasForeignKey(achi => achi.GameID) 
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //Fillin the datebase with data
            Developer CDPR = new Developer() { Id = 1, Name = "CD Project Red" , Location="Poland",FoundationYear=1995};
            Developer Valve = new Developer() { Id = 2, Name = "Valve Inc", Location = "Lord Gaben's Residency",FoundationYear=1990 };
            Developer EA = new Developer() { Id = 3, Name = "EA Games", Location = "Whereever the money is", FoundationYear = 2000 };
            Developer Ubisoft = new Developer() { Id = 4, Name = "Ubisoft Montreal", Location = "Canada", FoundationYear = 1993 };

            Game AC4 = new Game() {Id=1,DevID=Ubisoft.Id, Title= "Assassins's Creed 4 Black Flag" , Price=30, Genre="Parkour"};
            Game AC2 = new Game() { Id = 2, DevID = Ubisoft.Id, Title = "Assassins's Creed 2 ", Price = 20, Genre = "Parkour" };
            Game CP = new Game() { Id = 3, DevID = CDPR.Id, Title = "CyberPunk 2077", Price = 60, Genre = "Shooter" };
            Game W3 = new Game() { Id = 4, DevID = CDPR.Id, Title = "The Witcher 3 Wild Hunt", Price = 40, Genre = "RPG" };
            Game CS = new Game() { Id = 5, DevID = Valve.Id, Title = "Counter Strike : Global Offensive", Price = 0, Genre = "Shooter" };
            Game HL3 = new Game() { Id = 6, DevID = Valve.Id, Title = "Half-Life 3 The never ending story", Price = 99, Genre = "Shooter" };
            Game FF = new Game() { Id = 7, DevID = EA.Id, Title = "FIFA20", Price = 40, Genre ="Sport" };
            Game FF2 = new Game() { Id = 8, DevID = EA.Id, Title = "FIFA30", Price = 50, Genre = "Sport" };
            Game FF3 = new Game() { Id = 9, DevID = EA.Id, Title = "FIFA40", Price = 60, Genre = "Sport" };

            Achievement HS = new Achievement() { Id = 1, Name = "Headshot", Bonuspoints = 10, GameID = CS.Id };
            Achievement RT = new Achievement() { Id = 2, Name = "Retake the site", Bonuspoints = 10, GameID = CS.Id };
            Achievement ACE = new Achievement() { Id = 3, Name = "Get an Ace", Bonuspoints = 10, GameID = CS.Id };
            Achievement A4 = new Achievement() { Id = 4, Name = "Kill the templar leader", Bonuspoints = 50, GameID = AC4.Id };
            Achievement A42 = new Achievement() { Id = 5, Name = "Get the Jackdow", Bonuspoints = 10, GameID = AC4.Id };
            Achievement A2 = new Achievement() { Id = 6, Name = "Complete Ezio's story", Bonuspoints = 100, GameID = AC2.Id };
            Achievement FF1 = new Achievement() { Id = 7, Name = "You fell again", Bonuspoints = 10, GameID = FF.Id };
            Achievement FF22 = new Achievement() { Id = 8, Name = "And again", Bonuspoints = 10, GameID = FF2.Id };
            Achievement FF33 = new Achievement() { Id = 9, Name = "Come on man get a life", Bonuspoints = 10, GameID = FF3.Id };
            Achievement HL = new Achievement() { Id = 10, Name = "We finally released it have fun", Bonuspoints = 99, GameID = HL3.Id };
            Achievement CPA = new Achievement() { Id = 11, Name = "The first crash", Bonuspoints = 0, GameID = CP.Id };
            Achievement W3A = new Achievement() { Id = 12, Name = "You've found the Wild Hunt", Bonuspoints = 30, GameID = W3.Id };
            Achievement W3A2 = new Achievement() { Id = 13, Name = "Ciri saved", Bonuspoints = 70, GameID = W3.Id };
            Achievement W3A3 = new Achievement() { Id = 14, Name = "Dandelion is my bro", Bonuspoints = 10, GameID = W3.Id };
            Achievement FF1A = new Achievement() { Id = 15, Name = "You scored a goalllll", Bonuspoints = 10, GameID = FF.Id };
            Achievement AA2 = new Achievement() { Id = 16, Name = "You listened to Ezio's Family to the first ime", Bonuspoints = 22, GameID = A2.Id };
            Achievement W3A4 = new Achievement() { Id = 17, Name = "Visited Novigrad for the first time", Bonuspoints = 10, GameID = W3.Id };

            modelBuilder.Entity<Developer>().HasData(CDPR, Valve, EA,Ubisoft);
            modelBuilder.Entity<Game>().HasData(AC2, AC4, CP, W3, CS, HL3,FF,FF2,FF3);
            modelBuilder.Entity<Achievement>().HasData(HS, RT, ACE,A4,A42,A2,FF1,FF22,FF33,HL,CPA,W3A,W3A2,W3A3,FF1A,AA2,W3A4);
        }
    }
}
