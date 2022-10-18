using System;
using System.Collections.Generic;
using PsychicsGame.DataService;
using PsychicsGame.Models;

namespace PsychicsGame.MainGame
{
    public class Game
    {
        private PsychicsService service = new PsychicsService();

        private List<PsychicModel> psychics = new List<PsychicModel>();

        private List<UserAnswerModel> userValue = new List<UserAnswerModel>();

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
            }
        }

        public void StartTest(int userNumber)
        {
            userValue.Add(new UserAnswerModel { Value = userNumber });

            foreach (var psychic in psychics)
            {
                if (psychic.Value == userNumber)
                {
                    psychic.Validity += 10;
                }
                else
                    psychic.Validity -= 10;
            }
        }

        // У меня не вышло сделать как в рекомендации:
        // Делаем в Игре метод, который сформирует и вернёт "Модель" Игры - простой класс
        // со всеми нужными данными - с "Моделями" экстрасенсов - GameModel, в котором будет
        // поле PsychicModel[] psychics { get; set; }. С этой моделью мы уже снаружи можем делать,
        // что хотим - на состояние основного объекта Игра это не повлияет - инкапсуляция сохранена.
        //
        // И Я попробовала IReadOnlyList, чтобы открыть Psychics и UserValue только для чтения. 
        // Возможно, Я что-то не допоняла, поэтому, оставила класс GameModel на будущее и выполнить рекомендации.
        public IReadOnlyList<PsychicModel> Psychics
        {
            get
            {
                return psychics.AsReadOnly();
            }
        }

        public IReadOnlyList<UserAnswerModel> UserValue
        {
            get
            {
                return userValue.AsReadOnly();
            }
        }
    }
}