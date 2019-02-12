using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameQuakeAPI.Models
{
    public class Dead
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public int playerDeaths { get; set; }
        public Dead(int id, string name)
        {
            playerId = id;
            playerName = name;
        }
        //SUBTRAIR MORTES
        public void Subtract()
        {
            playerDeaths--;
        }
        //ADICIONAR MORTES
        public void Add()
        {
            playerDeaths++;
        }
        //ALTERAR PLAYER
        public void ChangeDeadPlayer(int death)
        {
            playerDeaths = death;
        }
        //ALTER NOME
        public void ChangeDeadPlayerName(string name)
        {
            playerName = name;
        }
    }
}