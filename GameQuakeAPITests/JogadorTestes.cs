using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameQuakeAPITests
{
    [TestClass]
    public class JogadorTestes
    {
        [TestMethod]
        public void Criar_jogador()
        {
            var IdPlayerExpected = 1;
            var namePlayerExpected = "Serjão Berranteiro";
            var playerOne = PlayerFactory.Default().WithIdAndName(IdPlayerExpected, namePlayerExpected).Build();

            Assert.AreEqual(IdPlayerExpected, playerOne.playerId);
            Assert.AreEqual(namePlayerExpected, playerOne.playerName);
        }

        [TestMethod]
        public void Deve_permitir_a_alteracao_do_nome_do_jogador()
        {
            var IdPlayerExpected = 1;
            var namePlayerExpected = "Joselito";
            var playerOne = PlayerFactory.Default().Build();

            playerOne.ChangeName("Joselito");

            Assert.AreEqual(IdPlayerExpected, playerOne.playerId);
            Assert.AreEqual(namePlayerExpected, playerOne.playerName);
        }
    }
}
