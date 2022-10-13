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
                    Validity = 50
                },
                new PsychicModel
                {
                    Name = "Нострадамус",
                    Validity = 50
                },
                new PsychicModel
                {
                    Name = "Джуна",
                    Validity = 50
                },
                new PsychicModel
                {
                    Name = "Чумак",
                    Validity = 50
                }
            };
            return psychic;
        }
    }
}