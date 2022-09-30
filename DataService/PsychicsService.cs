using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychicsGame.Models;

namespace PsychicsGame.DataService
{
    public class PsychicsService
    {
        /// <summary>
        /// Заполняем данными по экстрасенсам
        /// </summary>
        /// <returns></returns>
        public List<PsychicModel> GetNewPsychics()
        {
            var psy = new List<PsychicModel>();

            psy.Add(new PsychicModel
            {
                Name = "Ванга",
                Validity = 50
            });
            psy.Add(new PsychicModel
            {
                Name = "Нострадамус",
                Validity = 50
            });
            psy.Add(new PsychicModel
            {
                Name = "Джуна",
                Validity = 50
            });
            psy.Add(new PsychicModel
            {
                Name = "Чумак",
                Validity = 50
            });
            return psy;
        }

        /// <summary>
        /// Получаем список экстрасенсов
        /// </summary>
        /// <returns></returns>
        internal List<PsychicModel> GetPsychics()
        {
            return (List<PsychicModel>)HttpContext.Current.Application["Psychics"];
        }

        /// <summary>
        /// Инициализируем список экстрасенсов
        /// </summary>
        internal void InitData()
        {
            HttpContext.Current.Application["Psychics"] = GetNewPsychics();
        }
    }
}