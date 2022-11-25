using System.ComponentModel.DataAnnotations;

namespace PsychicsGame.Models
{
    public class UserAnswerModel
    {
        [Required]
        public int UserValue { get; set; }
    }
}