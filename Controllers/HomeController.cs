using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PsychicsGame.MainGame;
using PsychicsGame.Models;
using PsychicsGame.DataService;

namespace PsychicsGame.Controllers
{

    public class HomeController : Controller
    {
        public Game game = new Game();

        public GameModel gameModel = new GameModel();

        public ActionResult Index()
        {
            ViewBag.Model = gameModel.psychics;

            Session["game"] = game;

            return View();
        }

        /// <summary>
        /// Получаем догадки экстрасенсов и сохраняем в сессию
        /// </summary>
        /// <returns></returns>
        public ActionResult StartGame()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;
            }
                
            game.StartGame();

            Session["game"] = game;

            game = Session["game"] as Game;

            ViewBag.Model = gameModel.psychics;

            return View("Index");
        }

        /// <summary>
        /// Проверка догадок экстрасенсов
        /// </summary>
        /// <returns></returns>
        public ActionResult StartTest()
        {
            if ((Request.Form["userValue"].Length == 0))
            {
                return View("Index");
            }

            if (Session["game"] == null)
            {
                Session["game"] = game;
            }
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;


                // Берём данные из формы
                int res = Convert.ToInt32(Request.Form["userValue"]);

                game.StartTest(res);
            }

            Session["game"] = game;

            game = Session["game"] as Game;

            ViewBag.Model = gameModel.psychics;

            return View("Index");
        }

        public ActionResult GetUserHistory()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;
            }

            ViewBag.Model = game;

            return View("Index");
        }

        public ActionResult GetPsychicsHistory()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;

            }

            ViewBag.Model = game;

            return View("Index");
        }
    }
}