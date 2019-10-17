using Staj.Business.Interface;
using Staj.Repository;
using Staj.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business
{
    public class UserTypeBusiness : IUserTypeBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PlayerRepository playerRepository;
        private readonly TeamRepository teamRepository;

        public UserTypeBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            playerRepository = new PlayerRepository(unitOfWork);
            teamRepository = new TeamRepository(unitOfWork);
        }
        public string getUserType(int uId)
        {
            throw new NotImplementedException();
        }
    }
}
