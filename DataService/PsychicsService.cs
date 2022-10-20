using System.Collections.Generic;
using PsychicsGame.Models;

namespace PsychicsGame.DataService
{
    public class PsychicsService
    {
        public List<PsychicModel> GetNewPsychics()
        {
            List<PsychicModel> psychic = new List<PsychicModel>
            {
                new PsychicModel
                {
                    Name = "Ванга",
                    Validity = 100
                },
                new PsychicModel
                {
                    Name = "Нострадамус",
                    Validity = 100
                },
                new PsychicModel
                {
                    Name = "Джуна",
                    Validity = 100
                },
                new PsychicModel
                {
                    Name = "Чумак",
                    Validity = 100
                },
                new PsychicModel
                {
                    Name = "Дух Хаоса",
                    Validity = 100
                },
                new PsychicModel
                {
                    Name = "Доктор Костя",
                    Validity = 100
                }
            };
            return psychic;
        }
    }
}