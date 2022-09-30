using System;
using System.Collections.Generic;

namespace PsychicsGame.Models
{
    /// <summary>
    /// Описание экстрасенса
    /// </summary>
    public class PsychicModel
    {
        /// <summary>
        /// Имя экстрасенса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Достоверность экстрасенса
        /// </summary>
        public int Validity { get; set; }

        /// <summary>
        /// Догадка экстрасенса
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// История догадок экстрасенса
        /// </summary>
        public List<PsychicAnswerModel> PsychicValue = new List<PsychicAnswerModel>();

        /// <summary>
        /// Добавить догадку экстрасенса в историю догадок
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(PsychicAnswerModel value)
        {
            PsychicValue.Add(value);
        }
    }
}