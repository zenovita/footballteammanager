using Staj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business.Interface
{
    public interface IUserBusiness
    {
        int getUserId(int uId);
        string getUserUsername(int uId);
        string getUserPassword(int uId);
        int getUserType(int uId);
        int getUserTeam(int uId);
        List<UserDomainModel> getAllUsers();
        string authenticateUser(UserDomainModel user);
    }
}
