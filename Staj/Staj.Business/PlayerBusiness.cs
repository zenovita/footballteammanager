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
    public class PlayerBusiness : IPlayerBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PlayerRepository playerRepository;
        private readonly PlayerSkillRepository playerSkillRepository;
        private readonly TeamRepository teamRepository;

        public PlayerBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            playerRepository = new PlayerRepository(unitOfWork);
            teamRepository = new TeamRepository(unitOfWork);
            playerSkillRepository = new PlayerSkillRepository(unitOfWork);
        }

        public string AddUpdatePlayer(PlayerDomainModel dm, int skillID)
        {
            string result = "";
            if (dm.playerId > 0) // Edit Player
            {
                Players player = playerRepository.SingleOrDefault(x => x.playerId == dm.playerId);

                if (player != null)
                {
                    player.playerName = dm.playerName;
                    player.position = dm.position;
                    player.skill = skillID;
                    player.teamId = dm.teamId;

                    playerRepository.Update(player);

                    result = "Updated";
                }
            }
            else // Add Player
            {
                Players player = new Players();

                player.playerName = dm.playerName;
                player.position = dm.position;
                player.skill = skillID;
                player.teamId = dm.teamId;

                playerRepository.Insert(player);

                result = "Added";
            }

            return result;
        }

        public string AddUpdatePlayerSkill(PlayerSkillsDomainModel dm)
        {
            throw new NotImplementedException();
        }

        public string DeletePlayer(int pId)
        {
            string result = "Failed";

            //if (dm.playerId > 0)
            {
                Players player = playerRepository.SingleOrDefault(x => x.playerId == pId);

                if (player != null)
                {
                    var playerSkill = playerSkillRepository.SingleOrDefault(x => x.id == player.skill);
                    int skillId = playerSkill.id;
                    playerRepository.Delete(x => x.playerId == pId);
                    playerSkillRepository.Delete(x => x.id == skillId);
                    
                    result = "Deleted";
                }
            }

            return result;
        }

        public List<PlayerDomainModel> GetAllPlayers()
        {
            List<PlayerDomainModel> list = playerRepository.GetAll().Select(m => new PlayerDomainModel { playerName = m.playerName, playerId = m.playerId, isPlaying = m.isPlaying, position = m.position, skill = m.skill, teamId = m.teamId}).ToList();


            return list;
        }
        public List<PlayerDomainModel> GetTeamPlayers(int teamId)
        {
            List<PlayerDomainModel> result = playerRepository.GetAll(x=>x.teamId == teamId).Select(m => new PlayerDomainModel { playerName = m.playerName, playerId = m.playerId, isPlaying = m.isPlaying, position = m.position, skill = m.skill, teamId = m.teamId }).ToList();
            return result;
        }
        public PlayerDomainModel getPlayer(int id)
        {
            Players player = playerRepository.SingleOrDefault(m => m.playerId == id);
            PlayerDomainModel pDM = new PlayerDomainModel();
            pDM.playerId = player.playerId;
            pDM.teamId = player.teamId;
            pDM.playerName = player.playerName;
            pDM.position = player.position;
            pDM.skill = player.skill;
            pDM.isPlaying = player.isPlaying;

            return pDM;
        }

        public int getPlayerId(int pId)
        {
            throw new NotImplementedException();
        }

        public string getPlayerName(int pId)
        {
            return pId.ToString();
        }

        public int getPlayerSkill(int pId)
        {
            throw new NotImplementedException();
        }

        public int getPlayerTeam(int pId)
        {
            throw new NotImplementedException();
        }

        public int getPlayerTeamId(int pId)
        {
            throw new NotImplementedException();
        }


    }
}
