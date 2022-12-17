using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychicsGame.Models;

namespace PsychicsGame.PsychicNamespace
{
    public class Psychic
    {
        private Random random;

        private string names;

        private int validity;

        private int values;

        public List<PsychicAnswerModel> PsychicValues = new List<PsychicAnswerModel>();

        /// <summary>
        /// Добавить догадку экстрасенса в список догадок
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(PsychicAnswerModel value)
        {
            PsychicValues.Add(value);
        }

        public Psychic()
        {
            random = new Random();
        }

        public int GenerateRandomValue()
        {
            int value = random.Next(10, 99);
            return value;

        }

        public PsychicModel GetPsychicModel()
        {
            var model = new PsychicModel();
            model.Name = names;
            model.Validity = validity;
            model.Value = values;
            return model;
        }
    }
}