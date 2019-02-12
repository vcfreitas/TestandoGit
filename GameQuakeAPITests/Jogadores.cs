using GameQuakeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameQuakeAPITests
{
        internal class PlayerFactory
    {
        private Player playerOne;

        private PlayerFactory()
        {
            playerOne = new Player(1, "Teste");
        }

        public static PlayerFactory Default()
        {
            return new PlayerFactory();
        }

        public PlayerFactory WithID(int id)
        {
            playerOne = new Player(id);
            return this;
        }

        public PlayerFactory WithIdAndName(int id, string name)
        {
            playerOne = new Player(id, name);
            return this;
        }

        public Player Build()
        {
            if (playerOne == null)
                throw new Exception("Não criado");

            return playerOne;
        }
    }
}
