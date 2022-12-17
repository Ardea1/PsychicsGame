using System.ComponentModel.DataAnnotations;

namespace PsychicsGame.Models
{
    public class UserAnswerModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Range(10, 99, ErrorMessage = "Значение должно быть больше либо ровно {1} и меньше либо равно {2}.")]
        public int UserValue { get; set; }
    }
}