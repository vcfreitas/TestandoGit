using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameQuakeAPI.Models
{
    public class Game
    {
        public int gameId { get; set; }
        public int total_kills { get; set; }
        public virtual List<Player> players { get; set; }
        public virtual List<Dead> kills { get; set; }

        public Game()
        {
            players = new List<Player>();
            kills = new List<Dead>();
        }

        //ADICIONAR NOVO JOGADOR
        public void AddPlayer(Player player)
        {
            var exists = players.FirstOrDefault(x => x.playerId == player.playerId);
            if (exists == null)
            {
                players.Add(player);
                AddPlayerDeath(player);

                var deadOnePlayer = kills.FirstOrDefault(x => x.playerId == player.playerId);
                deadOnePlayer.ChangeDeadPlayer(0);
            }
        }
        //ADICIONAR NOVO JOGADOR MORTE
        private void AddPlayerDeath(Player player)
        {
            var playerDead = players.FirstOrDefault(x => x.playerId == player.playerId);
            if (playerDead == null)
                playerDead = player;

            var newDeadPlayer = new Dead(player.playerId, player.playerName);
            newDeadPlayer.Add();
            kills.Add(newDeadPlayer);
        }
        //ALTERAR NOME DO JOGADOR
        public void ChangePlayerName(Player player, string name)
        {
            var changePlayer = players.FirstOrDefault(x => x.playerId == player.playerId);
            var changePlayerDead = kills.FirstOrDefault(x => x.playerId == player.playerId);
            if (changePlayer != null && changePlayerDead != null)
            {
                changePlayer.ChangeName(name);
                changePlayerDead.ChangeDeadPlayerName(name);
            }
        }
        //MORTE POR WORD
        public void DeadWord(Player player)
        {
            var exists = kills.FirstOrDefault(x => x.playerId == player.playerId);
            if (exists != null)
            {
                exists.Subtract();
            }
            total_kills++;
        }
        //MORTE POR PLAYERS
        public void DeadPlayer(Player playerDead)
        {
            var exists = kills.FirstOrDefault(x => x.playerId == playerDead.playerId);
            if (exists != null)
            {
                exists.Add();
            }
            else
            {
                AddPlayerDeath(playerDead);
            }
            total_kills++;
        }
    }
}