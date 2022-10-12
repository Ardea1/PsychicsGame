using System.Collections.Generic;
using PsychicsGame.Models;

namespace PsychicsGame.DataService
{
    public class PsychicsService
    {
        public List<PsychicModel> GetNewPsychics()
        {
            var psy = new List<PsychicModel>();

            psy.Add(new PsychicModel
            {
                Name = "Ванга",
                Validity = 50
            });
            psy.Add(new PsychicModel
            {
                Name = "Нострадамус",
                Validity = 50
            });
            psy.Add(new PsychicModel
            {
                Name = "Джуна",
                Validity = 50
            });
            psy.Add(new PsychicModel
            {
                Name = "Чумак",
                Validity = 50
            });
            return psy;
        }
    }
}