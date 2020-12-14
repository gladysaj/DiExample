using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuchnerDi;
using System.Net.NetworkInformation;
using BuchnerDi_Tests.Utilities;
using System;
using BuchnerDi.Constants;

namespace BuchnerDi_Tests
{
    [TestClass]
    public class Setup_tests
    {
        [TestMethod]
        public void TestsCanFail()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AskForAmountOfPlayers_NullReAsksPlayer()    //This is a great function!
        {
            var pi = new PlayerInterfaceTestTool();
            var sut = new Setup(pi);
            pi.AddFuturePlayerInput(null);
            pi.AddFuturePlayerInput("1");

            sut.AskForAmountOfPlayers();

            Assert.AreEqual(PlayerInterfaceQuestions.MustEnterAValidNumber, pi.NextTell());
        }
        [TestMethod]
        public void AskForAmountOfPlayers_CharacterReAsksPlayer()
        {
            var pi = new PlayerInterfaceTestTool();
            var sut = new Setup(pi);
            pi.AddFuturePlayerInput("a");
            pi.AddFuturePlayerInput("1");

            sut.AskForAmountOfPlayers();

            Assert.AreEqual(PlayerInterfaceQuestions.MustEnterAValidNumber, pi.NextTell());
        }
        [TestMethod]
        public void AskForAmountOfPlayers_0ReAsksPlayer()
        {
            var pi = new PlayerInterfaceTestTool();
            var sut = new Setup(pi);
            pi.AddFuturePlayerInput("0");
            pi.AddFuturePlayerInput("1");

            sut.AskForAmountOfPlayers();

            Assert.AreEqual(PlayerInterfaceQuestions.MustEnterAValidNumber, pi.NextTell());
        }
        [TestMethod]
        public void AskForAmountOfPlayers_7AsksPlayer()
        {
            var pi = new PlayerInterfaceTestTool();
            var sut = new Setup(pi);
            pi.AddFuturePlayerInput("7");
            pi.AddFuturePlayerInput("1");

            sut.AskForAmountOfPlayers();

            Assert.AreEqual(PlayerInterfaceQuestions.MustEnterAValidNumber, pi.NextTell());
        }
    }
}
