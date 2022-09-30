using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PsychicsGame.Models
{
    public class UserAnswerModel
    {
        /// <summary>
        /// Число, загаданное пользователем
        /// </summary>
        [Required]
        [Range(10, 99, ErrorMessage = "Введите число в заданном диапазоне")]
        public int Value { get; set; }
    }
}