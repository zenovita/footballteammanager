using Staj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business.Interface
{
    public interface ITeamBusiness
    {
        int getTeamId(int tId);
        string getTeamName(int tId);
        int getTeamGamePlayed(int tId);
        int getTeamWin(int tId);
        int getTeamLose(int tId);
        int getTeamDraw(int tId);
        int getTeamGoalAgainst(int tId);
        int getTeamGoalDifference(int tId);
        int getTeamPoint(int tId);
        List<TeamDomainModel> getAllTeams();
        TeamDomainModel getTeam(int teamId);
        List<PlayerDomainModel> getPlayers(int teamId);
        string AddUpdateTeam(TeamDomainModel dm);
        string AddUpdateTeam(int teamId);
        string DeleteTeam(int teamId);
    }
}
