using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PsychicsGame.MainGame;
using PsychicsGame.Models;

namespace PsychicsGame.Controllers
{

    public class HomeController : Controller
    {
        public Game game = new Game();

        public GameModel gameModel = new GameModel();

        public ActionResult Index()
        {
            ViewBag.Model = game.psychics;

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

            ViewBag.Model = game.psychics;

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
                int userNumber = Convert.ToInt32(Request.Form["userValue"]);

                game.StartTest(userNumber);
            }

            Session["game"] = game;

            game = Session["game"] as Game;

            ViewBag.Model = game.psychics;

            return View("Index");
        }

        public ActionResult GetUserHistory()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;
            }

            ViewBag.Model = game.psychics;
            ViewBag.ModelUserAnswer = game.userValue;

            return View("Index");
        }

        public ActionResult GetPsychicsHistory()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;
            }

            ViewBag.Model = game.psychics;
            ViewBag.ModelPsychicAnswer = game.psychicAnswer;

            return View("Index");
        }
    }
}