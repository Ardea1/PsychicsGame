using System;
using System.Web.Mvc;
using PsychicsGame.MainGame;

namespace PsychicsGame.Controllers
{

    public class HomeController : Controller
    {
        public Game game = new Game();

        public StorageGame storageGame = new StorageGame();

        public ActionResult Index()
        {
            ViewBag.Model = game.Psychics;

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

            ViewBag.Model = game.Psychics;

            return PartialView("_Game");
        }

        /// <summary>
        /// Проверка догадок экстрасенсов
        /// </summary>
        /// <returns></returns>
        public ActionResult AnswerСheck()
        {
            if ((Request.Form["userValue"].Length == 0))
            {
                return View("_Game");
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

                game.AnswerСheck(userNumber);
            }

            Session["game"] = game;

            game = Session["game"] as Game;

            ViewBag.Model = game.Psychics;

            return PartialView("_Game");
        }

        public ActionResult GetHistory()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;
            }

            ViewBag.Model = game.Psychics;
            ViewBag.ModelUserAnswer = game.UserValue;
            ViewBag.ModelPsychicAnswer = game.Psychics;

            return PartialView("_GetHistory");
        }

        public ActionResult Game()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;
            }

            ViewBag.Model = game.Psychics;
            ViewBag.ModelUserAnswer = game.UserValue;

            return PartialView("_Game");
        }

        public ActionResult SaveGame()
        {
            if (Session["game"] != null)
            {
                storageGame.SaveGame(game);
            }

            ViewBag.Model = game.Psychics;
            ViewBag.ModelUserAnswer = game.UserValue;

            return PartialView("_Game");
        }

        public ActionResult LoadGame()
        {
            storageGame.LoadGame();

            //ViewBag.Model = game.Psychics;
            //ViewBag.ModelUserAnswer = game.UserValue;

            return PartialView("_Game");
        }

        public ActionResult ClearGame()
        {
            Session.Clear();

            //ViewBag.Model = game.Psychics;
            //ViewBag.ModelUserAnswer = game.UserValue;

            return PartialView("_Game");
        }
    }
}

