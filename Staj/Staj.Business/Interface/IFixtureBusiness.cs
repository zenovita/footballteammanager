using Staj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business.Interface
{
    public interface IFixtureBusiness
    {
        string getFixtureTeam(int fId);
        List<FixtureDomainModel> GetAllGroups();
        List<FixtureDomainModel> GetAllTeams();
        string AddUpdateFixtureTeam(FixtureDomainModel dm);
        string DeleteFixtureTeam(FixtureDomainModel dm);
    }
}
