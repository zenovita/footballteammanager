using Staj.Business.Interface;
using Staj.Domain;
using Staj.Repository;
using Staj.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Staj.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PlayerRepository playerRepository;
        private readonly TeamRepository teamRepository;
        private readonly UserRepository userRepository;

        public UserBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            playerRepository = new PlayerRepository(unitOfWork);
            teamRepository = new TeamRepository(unitOfWork);
            userRepository = new UserRepository(unitOfWork);
        }

        public string authenticateUser(UserDomainModel user)
        {
            string result = "Failed";

            //if (dm.playerId > 0)
            {
                Users _user = userRepository.SingleOrDefault(m=>m.username == user.username && m.password == user.password);

                if(_user != null)
                {
                    if(_user.userType == 1) // admin
                    {
                        result = "Admin";
                    }
                    else // standard
                    {
                        result = "Standard";
                    }
                }
            }
            return result;
        }

        public List<UserDomainModel> getAllUsers()
        {
            List<UserDomainModel> list = userRepository.GetAll().Select(m => new UserDomainModel { username = m.username, password = m.password }).ToList();

            return list;
        }

        public int getUserId(int uId)
        {
            throw new NotImplementedException();
        }

        public string getUserPassword(int uId)
        {
            throw new NotImplementedException();
        }

        public int getUserTeam(int uId)
        {
            throw new NotImplementedException();
        }

        public int getUserType(int uId)
        {
            throw new NotImplementedException();
        }

        public string getUserUsername(int uId)
        {
            throw new NotImplementedException();
        }
    }
}
