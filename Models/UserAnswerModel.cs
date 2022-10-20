using System.ComponentModel.DataAnnotations;

namespace PsychicsGame.Models
{
    public class UserAnswerModel
    {
        [Required]
        // [Range(10, 99, ErrorMessage = "Введите число в заданном диапазоне")]
        public int Value { get; set; }
    }
}