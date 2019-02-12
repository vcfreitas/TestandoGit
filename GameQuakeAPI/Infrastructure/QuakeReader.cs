using GameQuakeAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GameQuakeAPI.Infrastructure
{
    public class QuakeReader
    {
        public List<Game> ProcessRows(StreamReader streamFile)
        {
            var game = new Game();
            var games = new List<Game>();
            var actions = new Regex("(InitGame|ClientConnect|ClientUserinfoChanged|Kill)");

            int gameId = 0;
            string row;

            while ((row = streamFile.ReadLine()) != null)
            {
                Match action = actions.Match(row);

                switch (action.Value)
                {
                    case "InitGame":
                        gameId++;
                        game = NewGame(games, gameId);
                        break;
                    case "ClientConnect":
                        NewPlayer(game, row);
                        break;
                    case "ClientUserinfoChanged":
                        ChangePlayerName(game, row);
                        break;
                    case "Kill":
                        NewDead(game, row);
                        break;
                    default:
                        break;
                }
            }

            return games;
        }
        public Game NewGame(List<Game> games, int gameId)
        {
            Game game = new Game() { gameId = gameId };
            games.Add(game);
            return game;
        }
        public void NewPlayer(Game game, string row)
        {
            var action = "ClientConnect: ";
            var playerId = int.Parse(row.Substring(row.IndexOf(action) + action.Length));
            game.AddPlayer(new Player(playerId));
        }
        public void ChangePlayerName(Game game, string row)
        {
            var action = " ClientUserinfoChanged: ";

            var strName = row.Substring(row.IndexOf(action) + action.Length);
            var id = int.Parse(strName.Substring(0, strName.IndexOf(@"n\")));

            strName = row.Substring(row.IndexOf(@"n\") + 2);
            var name = strName.Substring(0, strName.IndexOf(@"\t\"));

            game.ChangePlayerName(new Player(id), name);
        }
        public void NewDead(Game game, string row)
        {
            var action = " Kill: ";
            string strPlayers = row.Substring(row.IndexOf(action) + action.Length);
            strPlayers = strPlayers.Substring(0, strPlayers.IndexOf(": "));
            string[] infor = strPlayers.Split(' ');

            var playerIdKill = int.Parse(infor[0]);
            var playerIdDead = int.Parse(infor[1]);

            if (playerIdKill == 1022)
                game.DeadWord(new Player(playerIdDead));
            else game.DeadPlayer(new Player(playerIdDead));
        }
    }
}