using Staj.Business.Interface;
using Staj.Domain;
using Staj.Repository;
using Staj.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business
{
    public class FixtureBusiness : IFixtureBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PlayerRepository playerRepository;
        private readonly TeamRepository teamRepository;
        private readonly FixtureRepository fixtureRepository;

        public FixtureBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            playerRepository = new PlayerRepository(unitOfWork);
            teamRepository = new TeamRepository(unitOfWork);
            fixtureRepository = new FixtureRepository(unitOfWork);

        }
        public string AddUpdateFixtureTeam(FixtureDomainModel dm)
        {
            throw new NotImplementedException();
        }

        public string DeleteFixtureTeam(FixtureDomainModel dm)
        {
            throw new NotImplementedException();
        }

        public List<FixtureDomainModel> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public List<FixtureDomainModel> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public string getFixtureTeam(int fId)
        {
            throw new NotImplementedException();
        }
    }
}
