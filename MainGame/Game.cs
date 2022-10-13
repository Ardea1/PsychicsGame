using System;
using System.Collections.Generic;
using PsychicsGame.DataService;
using PsychicsGame.Models;

namespace PsychicsGame.MainGame
{
    public class Game
    {
        private PsychicsService service = new PsychicsService();

        public List<PsychicModel> psychics = new List<PsychicModel>();

        public List<UserAnswerModel> userValue = new List<UserAnswerModel>();

        public List<PsychicAnswerModel> psychicAnswer = new List<PsychicAnswerModel>();

        public void StartGame()
        {
            if (psychics.Count == 0)
            {
                psychics = service.GetNewPsychics();
            }
            
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
            // GetGameModel();
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
            _ = new GameModel
            {
                Psychics = psychics
            };
        }

    }
}