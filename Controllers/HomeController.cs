﻿using System;
using System.Web.Mvc;
using PsychicsGame.MainGame;
using PsychicsGame.Models;

namespace PsychicsGame.Controllers
{

    public class HomeController : Controller
    {
        public Game game = new Game();

        public ActionResult Index()
        {
            var model = game.GetModel();

            return View(model);
        }

        /// <summary>
        /// Получаем догадки экстрасенсов и сохраняем в сессию
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PreventDuplicateRequest]
        public ActionResult StartRound()
        {
            if (ModelState.IsValid)
            {
                if (Session["game"] != null)
                {
                    game = Session["game"] as Game;
                }

                game.StartRound();

                Session["game"] = game;

                game = Session["game"] as Game;

                var model = game.GetModel();

                return PartialView("_UserAnswer", model);
            }
            game = Session["game"] as Game;
            var viewModel = game.GetModel();
            return PartialView("_UserAnswer", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PreventDuplicateRequest]
        public ActionResult AnswerСheck()
        {
            if (ModelState.IsValid)
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

                var model = game.GetModel();

                return PartialView("_Game", model);
            }
            game = Session["game"] as Game;
            var viewModel = game.GetModel();
            return PartialView("_Game", viewModel);
        }

        public ActionResult Game()
        {
            if (Session["game"] != null)
            {
                game = Session["game"] as Game;
            }

            var model = game.GetModel();

            return PartialView("_Game", model);
        }

        public ActionResult ClearGame()
        {
            Session.Clear();

            var model = game.GetModel();

            return PartialView("_Game", model);
        }
    }
}

