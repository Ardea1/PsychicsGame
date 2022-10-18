using System.Collections.Generic;

namespace PsychicsGame.Models
{
    public class GameModel
    {
        public List<PsychicModel> Psychics { get; set; }

        public List<UserAnswerModel> UserValue { get; set; }
    }
}