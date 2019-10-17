using Staj.Domain;
using Staj.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business.Interface
{
    public interface IPlayerBusiness
    {
        PlayerDomainModel getPlayer(int id);
        string getPlayerName(int pId);
        List<PlayerDomainModel> GetAllPlayers();
        int getPlayerSkill(int pId);
        int getPlayerTeam(int pId);
        int getPlayerId(int pId);
        int getPlayerTeamId(int pId);
        string AddUpdatePlayer(PlayerDomainModel dm, int skillID);
        string AddUpdatePlayerSkill(PlayerSkillsDomainModel dm);
        string DeletePlayer(int pId);
        List<PlayerDomainModel> GetTeamPlayers(int teamId);
    }
}
