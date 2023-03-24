﻿using System;
using Connect4Game_BusinessLogic_Contracts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Game_BusinessLogic
{
    public class LogicController : ILogicController
    {
        public List<IGame> GameList { get; set; }
        public List<IPlayer> PlayerList { get; set; }
        public List<IPlayer> Queue { get; set; }

        public LogicController()
        {
            GameList = new List<IGame>();
            PlayerList = new List<IPlayer>();
            Queue = new List<IPlayer>();
        }

        public void JoinQueue(IPlayer playerI)
        {
            string playerID = playerI.PlayerID;
            string color = playerI.Color;
            string name = playerI.GetName();
            IPlayer player = new Player(playerID, name, color);
            PlayerList.Add(player);
        }

        public IGame StartGame(string playerID1, string playerID2)
        {
            int col = 6;
            int row = 7;
            Board Board = new Board(col, row);
            IGame game = new Game(playerID1, playerID2);
            GameList.Add(game);
            return game;
        }

        public void EndGame(string gameID)
        {
            IGame game = GetGameFromID(gameID);
            GameList.Remove(game);
        }

        public void MakeMoveInGame(string gameID, string playerID, int col)
        {
            var Game = new Game(gameID, playerID);
            IPlayer p = GetPlayerFromID(playerID);
            Game.MakeMove(p, col);
        }

        public IGame GetGameFromID(string gameID)
        {
            foreach (IGame game in GameList)
            {
                if (game.GameID == gameID)
                {
                    return game;
                }
            }
            throw new Exception();
        }

        public IPlayer GetPlayerFromID(string playerID)
        {
            foreach (IPlayer player in PlayerList)
            {
                if (player.PlayerID == playerID)
                {
                    return player;
                }
            }
            throw new Exception();
        }
    }
}
