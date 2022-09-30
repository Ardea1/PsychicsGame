using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychicsGame.Models
{
    public class PsychicAnswerModel
    {
        /// <summary>
        /// Имя экстрасенса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Догадка экстрасенса
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Результат угадывания, верно/неверно
        /// </summary>
        public bool Result;
    }
}