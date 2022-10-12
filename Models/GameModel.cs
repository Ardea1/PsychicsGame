using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychicsGame.Models;

namespace PsychicsGame.Models
{
    public class GameModel
    {
        public List<PsychicModel> psychics = new List<PsychicModel>();

        public List<PsychicAnswerModel> psychicAnswer;
    }
}