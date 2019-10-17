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
    public class TeamBusiness : ITeamBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PlayerRepository playerRepository;
        private readonly TeamRepository teamRepository;
        private readonly PlayerSkillRepository playerSkillRepository;

        public TeamBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            playerRepository = new PlayerRepository(unitOfWork);
            teamRepository = new TeamRepository(unitOfWork);
            playerSkillRepository = new PlayerSkillRepository(unitOfWork);
        }

        public string AddUpdateTeam(TeamDomainModel dm)
        {
            string result = "";
            if (dm.teamId > 0) // Edit Player
            {
                Teams team = teamRepository.SingleOrDefault(x => x.teamId == dm.teamId);

                if (team != null)
                {

                    team.teamName = dm.teamName;
                    team.gamePlayed = dm.gamePlayed;
                    team.win = dm.win;
                    team.lose = dm.lose;
                    team.draw = dm.draw;
                    team.goalAgainst = dm.goalAgainst;
                    team.goalDifference = dm.goalDifference;
                    team.point = dm.point;

                    teamRepository.Update(team);

                    result = "Updated";
                }
            }
            else // Add Player
            {
                Teams team = new Teams();

                team.teamName = dm.teamName;
                team.gamePlayed = dm.gamePlayed;
                team.win = dm.win;
                team.lose = dm.lose;
                team.draw = dm.draw;
                team.goalAgainst = dm.goalAgainst;
                team.goalDifference = dm.goalDifference;
                team.point = dm.point;

                teamRepository.Insert(team);

                result = "Added";
            }

            return result;
        }

        public string AddUpdateTeam(int teamId)
        {
            TeamDomainModel teamDM = getTeam(teamId);
            string result = "";
            //if (teamDM.teamId > 0) // Edit Player
            //{
            //    Teams team = teamRepository.SingleOrDefault(x => x.teamId == teamId);

            //    if (team != null)
            //    {
            //        team.teamName = dm.teamName;
            //        team.gamePlayed = dm.gamePlayed;
            //        team.win = dm.win;
            //        team.lose = dm.lose;
            //        team.draw = dm.draw;
            //        team.goalAgainst = dm.goalAgainst;
            //        team.goalDifference = dm.goalDifference;
            //        team.point = dm.point;

            //        teamRepository.Update(team);

            //        result = "Updated";
            //    }
            //}
            //else // Add Player
            //{
            //    Teams team = new Teams();

            //    team.teamName = dm.teamName;
            //    team.gamePlayed = dm.gamePlayed;
            //    team.win = dm.win;
            //    team.lose = dm.lose;
            //    team.draw = dm.draw;
            //    team.goalAgainst = dm.goalAgainst;
            //    team.goalDifference = dm.goalDifference;
            //    team.point = dm.point;

            //    teamRepository.Insert(team);

            //    result = "Added";
            //}

            return result;
        }

        public string DeleteTeam(int teamId)
        {
            string result = "Failed";

            {
                Teams team = teamRepository.SingleOrDefault(x => x.teamId == teamId);
                if (team != null)
                {
                    List<PlayerDomainModel> teamPlayers = getPlayers(teamId);
                    var arr = teamPlayers.ToArray();
                    for(int i = 0; i < arr.Length; i++)
                    {
                        int temp = arr[i].skill;
                        int temp2 = arr[i].playerId;
                        //var playerSkill = playerSkillRepository.SingleOrDefault(x => x.id == temp);
                        //int skillId = playerSkill.id;
                        playerRepository.Delete(x => x.playerId == temp2);
                        playerSkillRepository.Delete(x => x.id == temp);
                    }
                    teamRepository.Delete(x => x.teamId == teamId);

                    result = "Deleted";
                }
            }

            return result;
        }

        public List<TeamDomainModel> getAllTeams()
        {
            List<TeamDomainModel> list = teamRepository.GetAll().Select(m => new TeamDomainModel { teamId = m.teamId, draw = m.draw, gamePlayed=m.gamePlayed, goalAgainst=m.goalAgainst, goalDifference=m.goalDifference, lose=m.lose, point=m.point, teamName=m.teamName, win=m.win}).ToList();
            return list;
        }

        public List<PlayerDomainModel> getPlayers(int teamId)
        {
            List<PlayerDomainModel> result = playerRepository.GetAll().Where(x=>x.teamId == teamId).Select(m => new PlayerDomainModel { playerName = m.playerName, playerId = m.playerId, position = m.position, isPlaying = m.isPlaying, skill = m.skill, teamId = m.teamId}).ToList();
            return result;
        }

        public TeamDomainModel getTeam(int teamId)
        {
            Teams team = teamRepository.SingleOrDefault(m => m.teamId == teamId);
            TeamDomainModel result = new TeamDomainModel();

            result.teamId = team.teamId;
            result.teamName = team.teamName;
            result.gamePlayed = team.gamePlayed;
            result.win = team.win;
            result.lose = team.lose;
            result.draw = team.draw;
            result.goalAgainst = team.goalAgainst;
            result.goalDifference = team.goalDifference;
            result.point = team.point;

            return result;
        }

        public int getTeamDraw(int tId)
        {
            throw new NotImplementedException();
        }

        public int getTeamGamePlayed(int tId)
        {
            throw new NotImplementedException();
        }

        public int getTeamGoalAgainst(int tId)
        {
            throw new NotImplementedException();
        }

        public int getTeamGoalDifference(int tId)
        {
            throw new NotImplementedException();
        }

        public int getTeamId(int tId)
        {
            throw new NotImplementedException();
        }

        public int getTeamLose(int tId)
        {
            throw new NotImplementedException();
        }

        public string getTeamName(int tId)
        {
            string result = teamRepository.SingleOrDefault(m => m.teamId == tId).teamName;
            return result;
        }

        public int getTeamPoint(int tId)
        {
            throw new NotImplementedException();
        }

        public int getTeamWin(int tId)
        {
            throw new NotImplementedException();
        }
    }
}
