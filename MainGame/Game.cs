using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychicsGame.DataService;
using PsychicsGame.Models;

namespace PsychicsGame.MainGame
{
    public class Game
    {
        private GameModel gameModel = new GameModel();

        private PsychicsService service = new PsychicsService();

        private List<PsychicModel> psychics;

        private List<UserAnswerModel> userValue = new List<UserAnswerModel>();

        private List<PsychicAnswerModel> psychicAnswer = new List<PsychicAnswerModel>();

        public void StartGame()
        {
            GetGameModel();

            Random random = new Random();

            foreach (var psychic in psychics)
            {
                var answer = new PsychicAnswerModel
                {
                    Value = random.Next(10, 99)
                };
                psychic.AddValue(answer);
                psychic.Value = answer.Value;

                psychicAnswer.Add(new PsychicAnswerModel { Name = psychic.Name, Value = psychic.Value });
            }
        }

        public void StartTest(int res)
        {
            userValue.Add(new UserAnswerModel { Value = res });

            foreach (var psychic in psychics)
            {

                if (psychic.Value == res)
                {
                    psychic.Validity += 10;

                }
                else
                    psychic.Validity -= 10;
            }
        }

        private void GetGameModel()
        {
            psychics = gameModel.psychics;
        }

    }
}