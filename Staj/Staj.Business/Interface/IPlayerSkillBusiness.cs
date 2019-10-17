using Staj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business.Interface
{
    public interface IPlayerSkillBusiness
    {
        List<PlayerSkillsDomainModel> getCertainSkills(List<PlayerDomainModel> pdm);
        List<PlayerSkillsDomainModel> getAllSkills();
        PlayerSkillsDomainModel getPlayerSkills(int id);
        int AddUpdatePlayerSkill(PlayerSkillsDomainModel dm);
        int getPlayerSkillId(int pId);
        int getPlayerAtk(int pId);
        int getPlayerDef(int pId);
        int getPlayerPass(int pId);
        int getPlayerSpd(int pId);
        int getPlayerAvg(int pId);
    }
}
