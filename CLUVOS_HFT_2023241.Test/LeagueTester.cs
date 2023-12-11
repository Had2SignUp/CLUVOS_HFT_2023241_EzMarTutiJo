using Moq;
using System;
using CLUVOS_HFT_2023241.Logic;
using CLUVOS_HFT_2023241.Models;
using CLUVOS_HFT_2023241.Repository;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CLUVOS_HFT_2023241.Test
{
    [TestFixture]
    public class LeagueTester
    {
        LeagueLogic llog;
        Mock<IRepository<League>> mockLeagueRepository;

        [SetUp]
        public void Init()
        {
            mockLeagueRepository = new Mock<IRepository<League>>();
            mockLeagueRepository.Setup(t => t.ReadAll()).Returns(new List<League>()
            {
                new League(10,"Liga A","Hungary",true),
                new League(11,"Liga B","Hungary",true),
                new League(12,"Liga C","Hungary",false),
            }.AsQueryable());
            llog = new LeagueLogic(mockLeagueRepository.Object);
        }
        [Test]
        public void LeagueCreateTestCorrect()
        {
            var l = new League(13, " Liga", "Hungary", false);
            llog.Create(l);
            mockLeagueRepository.Verify(a => a.Create(l), Times.Once());
        }
        [Test]
        public void LeagueCreateTestIncorrect()
        {
            var l = new League(-2, "P Liga", "Greece", false);
            try
            {
                llog.Create(l);
            }
            catch (ArgumentException)
            {
            }
            mockLeagueRepository.Verify(a => a.Create(l), Times.Never());
        }
        [Test]
        public void LeagueReadTest()
        {

            try
            {
                llog.Read(10);
            }
            catch
            {

            }
            mockLeagueRepository.Verify(a => a.Read(10), Times.Once());
        }
    }
}
