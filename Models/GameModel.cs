using System.Collections.Generic;
using PsychicsGame.Models;

namespace PsychicsGame.Models
{
    public class GameModel
    {
        public List<PsychicModel> Psychics { get; set; }

        public List<PsychicAnswerModel> PsychicAnswer { get; set; }

        public List<UserAnswerModel> UserValue { get; set; }
    }
}