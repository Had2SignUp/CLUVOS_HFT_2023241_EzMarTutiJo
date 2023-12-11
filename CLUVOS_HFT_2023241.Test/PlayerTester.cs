using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUVOS_HFT_2023241.Logic;
using CLUVOS_HFT_2023241.Models;
using CLUVOS_HFT_2023241.Repository;

namespace CLUVOS_HFT_2023241.Test
{
    [TestFixture]
    internal class PlayerTester
    {
        PlayerLogic pl;
        Mock<IRepository<Player>> mockPlayerRepository;
        [SetUp]
        public void Init()
        {
            mockPlayerRepository = new Mock<IRepository<Player>>();
            pl = new PlayerLogic(mockPlayerRepository.Object);
        }
        [Test]
        public void CreateTest()
        {
            var p = new Player(2, "Kis Béla", 30, false, 70000, "Striker", 2);
            pl.Create(p);
            mockPlayerRepository.Verify(a => a.Create(p), Times.Once());
        }
        [Test]
        public void GetYoungestPlayerTest()
        {
            mockPlayerRepository.Setup(t => t.ReadAll()).Returns(new List<Player>()
            {
                new Player(1,"X Ádám",17,true,90000,"Goalkeeper",2),
                new Player(2,"Tóth Lajos",27,true,95000,"Striker",2),
                new Player(3,"Nagy István",24,true,75000,"Midfilder",3),
            }.AsQueryable());
            pl = new PlayerLogic(mockPlayerRepository.Object);
            Assert.AreEqual(pl.GetYoungestPlayerAge(), 17);
        }
    }
}
