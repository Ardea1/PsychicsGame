using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychicsGame.Models;

namespace PsychicsGame.Models
{
    public class GameModel
    {
        public List<PsychicModel> psychics { get; set; }

        public List<PsychicAnswerModel> psychicAnswer { get; set; }
    }
}