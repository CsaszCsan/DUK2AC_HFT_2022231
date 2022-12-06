using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Moq;
using DUK2AC_HFT_2022231.Models;
using DUK2AC_HFT_2022231.Repositroy;
using DUK2AC_HFT_2022231.Logic;
using System;

namespace DUK2AC_HFT_2022231.Test
{
    [TestFixture]
    public class Tester
    {
        AchievementLogic achievementLogic;
        GameLogic gameLogic;
        DeveloperLogic developerLogic;
        Mock<IRepo<Achievement>> mockachirepo;
        Mock<IRepo<Game>> mockgamerepo;
        Mock<IRepo<Developer>> mockdevrepo;

        [SetUp]
        public void Init()
        {
            mockdevrepo = new Mock<IRepo<Developer>>();


            Developer dev1 = new Developer()
            {
                Id = 1,
                Name = "CD Project Red",
                Location = "Poland"
            };
            Developer dev2 = new Developer()
            {
                Id = 2,
                Name = "Valve Inc",
                Location = "Lord Gaben's Residency"
            };



            developerLogic = new DeveloperLogic(mockdevrepo.Object);


            mockgamerepo = new Mock<IRepo<Game>>();

            Game game1 = new Game()
            {
                Id = 1,
                DevID = 1,
                Title = "The Witcher 3 Wild Hunt",
                Price = 40,
                Developer = dev1
            };
            Game game2 = new Game()
            {
                Id = 2,
                DevID = 1,
                Title = "Counter Strike : Global Offensive",
                Price = 0,
                Developer = dev2
            };
            Game game3 = new Game()
            {
                Id = 3,
                DevID = 1,
                Title = "Half-Life 3 The never ending story",
                Price = 99,
                Developer = dev2
            };


            gameLogic = new GameLogic(mockgamerepo.Object);

            mockachirepo = new Mock<IRepo<Achievement>>();

            Achievement achi1 = new Achievement()
            {
                Id = 1,
                Name = "Headshot",
                Bonuspoints = 10,
                GameID = 2,
                game = game2

            };
            Achievement achi2 = new Achievement()
            {
                Id = 2,
                Name = "Retake",
                Bonuspoints = 20,
                GameID = 2,
                game = game2

            };
            Achievement achi3 = new Achievement()
            {
                Id = 3,
                Name = "ROACH",
                Bonuspoints = 30,
                GameID = 1,
                game = game1

            };
            Achievement achi4 = new Achievement()
            {
                Id = 4,
                Name = "Released",
                Bonuspoints = 50,
                GameID = 3,
                game = game3

            };


            achievementLogic = new AchievementLogic(mockachirepo.Object);
            mockdevrepo.Setup((t) => t.ReadAll()).Returns(
                new List<Developer>()
                {
                    dev1, dev2
                }.AsQueryable);
            mockachirepo.Setup((t) => t.ReadAll()).Returns(
                new List<Achievement>()
                {
                    achi1, achi2,achi3,achi4
                }.AsQueryable);
            mockgamerepo.Setup((t) => t.ReadAll()).Returns(
                new List<Game>()
                {
                    game1, game2,game3
                }.AsQueryable);
        }



        [Test]
        public void GameCreateTest()
        {
            var game = new Game() { Id = 4, DevID = 1, Title = "The Witcher 3 Wild Hunt Hearts of Stone DLC", Price = 40 };


            gameLogic.Create(game);


            mockgamerepo.Verify(r => r.Create(game), Times.Once);
        }
        [Test]
        public void DevCreateTest()
        {
            var dev = new Developer() { Id = 3, Name = "3 Guys in a shed", Location = "A shed" };


            developerLogic.Create(dev);


            mockdevrepo.Verify(r => r.Create(dev), Times.Once);
        }
        [Test]
        public void AchiCreateTest()
        {
            var achi = new Achievement() { Id = 5, Name = "ASD", Bonuspoints = 20, GameID = 3 };


            achievementLogic.Create(achi);


            mockachirepo.Verify(r => r.Create(achi), Times.Once);
        }
        [Test]
        public void GetGameWithTheMostAchievementPointsTest()
        {
            var result = achievementLogic.GetGameWithTheMostAchievementPoints().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Half-Life 3 The never ending story", 50)));

        }
        [Test]
        public void DevsWithMostGamesMadeTest()
        {
            var result = gameLogic.DevsWithMostGamesMade().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Valve Inc",2)));
        }


    }
}
