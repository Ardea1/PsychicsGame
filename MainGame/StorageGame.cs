using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychicsGame.MainGame;

namespace PsychicsGame.MainGame
{
    public class StorageGame
    {
        public Game game = new Game();

        public void SaveGame (Game game)
        {
            HttpContext.Current.Session["game"] = game;
        }

        public Game LoadGame()
        {
            return (Game)HttpContext.Current.Session["game"];
        }
    }
}