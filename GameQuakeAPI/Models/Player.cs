using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameQuakeAPI.Models
{
    public class Player
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public Player(int id)
        {
            playerId = id;
        }

        public Player(int id, string name)
        {
            playerId = id;
            playerName = name;
        }
        //ALTERAR NOME
        public void ChangeName(string name)
        {
            playerName = name;
        }
    }
}