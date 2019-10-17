using Staj.Business.Interface;
using Staj.Domain;
using Staj.Repository;
using Staj.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Staj.Business
{
    public class PlayerSkillBusiness : IPlayerSkillBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PlayerRepository playerRepository;
        private readonly PlayerSkillRepository playerSkillRepository;
        private readonly TeamRepository teamRepository;

        public PlayerSkillBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            playerRepository = new PlayerRepository(unitOfWork);
            playerSkillRepository = new PlayerSkillRepository(unitOfWork);
            teamRepository = new TeamRepository(unitOfWork);
        }

        public int AddUpdatePlayerSkill(PlayerSkillsDomainModel dm)
        {
            int result = 0;
            if (dm.id > 0) // Edit Player
            {
                PlayerSkills playerSkill = playerSkillRepository.SingleOrDefault(x => x.id == dm.id);

                if (playerSkill != null)
                {
                    playerSkill.atk = dm.atk;
                    playerSkill.def = dm.def;
                    playerSkill.pass = dm.pass;
                    playerSkill.spd = dm.spd;

                    var obj = playerSkillRepository.Insert(playerSkill);

                    result = obj.id;
                }
            }
            else // Add Player
            {
                PlayerSkills playerSkill = new PlayerSkills();

                playerSkill.atk = dm.atk;
                playerSkill.def = dm.def;
                playerSkill.pass = dm.pass;
                playerSkill.spd = dm.spd;

                var obj = playerSkillRepository.Insert(playerSkill);

                result = obj.id;
            }

            return result;
        }

        public List<PlayerSkillsDomainModel> getAllSkills()
        {
            List<PlayerSkillsDomainModel> list = playerSkillRepository.GetAll().Select(m => new PlayerSkillsDomainModel { id = m.id, atk = m.atk, def = m.def, pass = m.pass, spd = m.spd }).ToList();
            return list;
        }

        public List<PlayerSkillsDomainModel> getCertainSkills(List<PlayerDomainModel> pdm)
        {
            List<PlayerSkillsDomainModel> result = new List<PlayerSkillsDomainModel>();
            var temp = pdm.ToArray();
            for (int i = 0; i < temp.Length; i++)
            {
                PlayerSkillsDomainModel temp2 = getPlayerSkills(temp[i].skill);
                result.Add(temp2);
            }
            return result;
        }

        public int getPlayerAtk(int pId)
        {
            throw new NotImplementedException();
        }

        public int getPlayerAvg(int pId)
        {
            throw new NotImplementedException();
        }

        public int getPlayerDef(int pId)
        {
            throw new NotImplementedException();
        }

        public int getPlayerPass(int pId)
        {
            throw new NotImplementedException();
        }

        public int getPlayerSkillId(int pId)
        {
            throw new NotImplementedException();
        }

        public PlayerSkillsDomainModel getPlayerSkills(int id)
        {
            PlayerSkills skills = playerSkillRepository.SingleOrDefault(m => m.id == id);
            PlayerSkillsDomainModel sDM = new PlayerSkillsDomainModel();
            sDM.id = skills.id;
            sDM.atk = skills.atk;
            sDM.def = skills.def;
            sDM.pass = skills.pass;
            sDM.spd = skills.pass;
            return sDM;
        }

        public int getPlayerSpd(int pId)
        {
            throw new NotImplementedException();
        }
    }
}
