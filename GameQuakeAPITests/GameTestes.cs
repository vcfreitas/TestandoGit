using GameQuakeAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameQuakeAPITests
{
    [TestClass]
    public class GameTestes
    {
        private Game game;
        public virtual Player players { get; set; }

        [TestInitialize]
        public void Iniciar()
        {
            game = new Game();
        }

        [TestMethod]
        public void Iniciando_Game()
        {
            var totalPlayersExpected = 0;
            var totalPlayers = game.players.Count();
            Assert.AreEqual(totalPlayersExpected, totalPlayers);
        }

        [TestMethod]
        public void Iniciando_Game_com_jogador()
        {
            var totalPlayersExpected = 1;
            var killer = PlayerFactory.Default().WithIdAndName(1, "Lucão").Build();
            game.AddPlayer(killer);
            Assert.AreEqual(totalPlayersExpected, game.players.Count());
        }

        [TestMethod]
        public void Iniciando_Game_com_dois_jogadores()
        {
            var totalPlayersExpected = 2;
            var player1 = PlayerFactory.Default().WithIdAndName(1, "Serjão Berranteiro").Build();
            var player2 = PlayerFactory.Default().WithIdAndName(2, "onça").Build();

            game.AddPlayer(player1);
            game.AddPlayer(player2);

            Assert.AreEqual(totalPlayersExpected, game.players.Count());
        }

        [TestMethod]
        public void Alterando_nome()
        {
            var IdPlayerExpected = 1;
            var namePlayerExpected = "Lucas";
            var killer = PlayerFactory.Default().WithIdAndName(IdPlayerExpected, namePlayerExpected).Build();
            game.AddPlayer(killer);

            game.ChangePlayerName(killer, "Lucas");

            Assert.AreEqual(IdPlayerExpected, killer.playerId);
            Assert.AreEqual(namePlayerExpected, killer.playerName);
        }
    }
}
