using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PsychicsGame.Models;
using PsychicsGame.DataService;
using System.Net;
using System.Net.Http;

namespace PsychicsGame.Controllers
{

    public class HomeController : Controller
    {
        PsychicsService service = new PsychicsService();
        public List<PsychicModel> psyData;

        public List<UserAnswerModel> userValue = new List<UserAnswerModel>();
        public List<PsychicAnswerModel> psychicAnswer = new List<PsychicAnswerModel>();

        public ActionResult Index()
        {
            psyData = service.GetNewPsychics();
            ViewBag.Model = psyData;

            ViewBag.ModelUserAnswer = userValue;
            ViewBag.ModelPsychicAnswer = psychicAnswer;

            return View();
        }

        /// <summary>
        /// Получаем догидки экстрасенсов и сохраняем в сессию
        /// </summary>
        /// <returns></returns>
        public ActionResult StartGame()
        {
            if (Session["psyData"] == null)
            {
                psyData = service.GetNewPsychics();
            }
            else
            {
                psyData = Session["psyData"] as List<PsychicModel>;
                userValue = Session["userData"] as List<UserAnswerModel>;
                psychicAnswer = Session["psychicAnswerData"] as List<PsychicAnswerModel>;
            }

            Random rnd = new Random();

            foreach (var p in psyData)
            {
                var answer = new PsychicAnswerModel
                {
                    Value = rnd.Next(10, 99)
                };
                p.AddValue(answer);
                p.Value = answer.Value;

                psychicAnswer.Add(new PsychicAnswerModel { Name = p.Name, Value = p.Value });
            }

            Session["psyData"] = psyData;

            psyData = Session["psyData"] as List<PsychicModel>;

            ViewBag.Model = psyData;

            Session["psychicAnswerData"] = psychicAnswer;

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

            if (Session["userData"] == null)
            {
                Session["userData"] = userValue;
            }
            if (Session["psyData"] != null)
            {
                psyData = Session["psyData"] as List<PsychicModel>;
                userValue = Session["userData"] as List<UserAnswerModel>;
                psychicAnswer = Session["psychicAnswerData"] as List<PsychicAnswerModel>;


                // Берём данные из формы
                int res = Convert.ToInt32(Request.Form["userValue"]);

                userValue.Add(new UserAnswerModel { Value = res });

                foreach (var p in psyData)
                {

                    if (p.Value == res)
                    {
                        p.Validity += 10;

                    }
                    else
                        p.Validity -= 10;
                }
            }

            Session["psyData"] = psyData;

            psyData = Session["psyData"] as List<PsychicModel>;

            ViewBag.Model = psyData;

            Session["userData"] = userValue;

            return View("Index");
        }

        public ActionResult GetUserHistory()
        {
            if (Session["userData"] != null)
            {
                psyData = Session["psyData"] as List<PsychicModel>;
                userValue = Session["userData"] as List<UserAnswerModel>;
            }

            ViewBag.Model = psyData;
            ViewBag.ModelUserAnswer = userValue;
            ViewBag.ModelPsychicAnswer = psychicAnswer;

            return View("Index");
        }

        public ActionResult GetPsychicsHistory()
        {
            if (Session["psyData"] != null)
            {
                psyData = Session["psyData"] as List<PsychicModel>;
                psychicAnswer = Session["psychicAnswerData"] as List<PsychicAnswerModel>;

            }

            ViewBag.Model = psyData;
            ViewBag.ModelPsychicAnswer = psychicAnswer;

            return View("Index");
        }
    }
}