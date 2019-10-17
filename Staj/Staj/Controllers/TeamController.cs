using Staj.Business;
using Staj.Business.Interface;
using Staj.Domain;
using Staj.Models;
using Staj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj.Controllers
{
    public class TeamController : Controller
    {
        ITeamBusiness teamBusiness;
        IPlayerBusiness playerBusiness;
        IPlayerSkillBusiness playerSkillBusiness;
        int temp_teamId;

        public TeamController(ITeamBusiness _teamBusiness, IPlayerBusiness _playerBusiness, IPlayerSkillBusiness _playerSkillBusiness)
        {
            teamBusiness = _teamBusiness;
            playerBusiness = _playerBusiness;
            playerSkillBusiness = _playerSkillBusiness;
        }
        // GET: Team
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult ShowTeams()
        {
            return View();
        }
        public JsonResult ShowTeam()
        {
            List<TeamViewModel> List = getTeamVM();
           
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteTeamPrompt(int teamId)
        {
            ViewBag.teamId = teamId;
            return PartialView("DeleteTeamPartial");
        }
        public string DeleteTeam(int teamId)
        {
            ViewBag.teamId = teamId;
            string result = teamBusiness.DeleteTeam(teamId);
            return result;
        }
        public ActionResult ShowPlayers(int teamId)
        {
            ViewBag.teamId = teamId;
            return PartialView("ShowPlayersPartial");
        }
        //public JsonResult GetPlayersJson()
        //{
        //    var result = getPlayers(temp_teamId);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult getPlayers(int teamId)
        {
            List<PlayerSkillRelationViewModel> result = new List<PlayerSkillRelationViewModel>();

            List<PlayerDomainModel> pdm = playerBusiness.GetTeamPlayers(teamId);
            //List<PlayerSkillsDomainModel> sdm = playerSkillBusiness.getCertainSkills(pdm);

            var temp = pdm.ToArray();
            //var temp2 = sdm.ToArray();
            for(int i = 0; i<temp.Length; i++)
            {
                PlayerViewModel a = new PlayerViewModel();
                PlayerSkillsDomainModel b = playerSkillBusiness.getPlayerSkills(temp[i].skill);
                PlayerSkillViewModel c = new PlayerSkillViewModel();

                AutoMapper.Mapper.Map(temp[i], a);
                AutoMapper.Mapper.Map(b, c);

                result.Add(new PlayerSkillRelationViewModel { PlayerVM = a, SkillVM = c });
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string AddEditTeam(TeamViewModel vm)
        {
            string result = "";

            TeamDomainModel dm = new TeamDomainModel();

            AutoMapper.Mapper.Map(vm, dm);

            result = result + " " + teamBusiness.AddUpdateTeam(dm);

            return result;
        }
        public ActionResult GetTeam(int teamId)
        {
            TeamDomainModel dm = teamBusiness.getTeam(teamId);
            TeamViewModel vm = new TeamViewModel();

            AutoMapper.Mapper.Map(dm, vm);

            ViewBag.teamId = teamId;

            return PartialView("EditTeamPartial", vm);
        }
        public List<TeamViewModel> getTeamVM()
        {
            List<TeamDomainModel> teamDM = teamBusiness.getAllTeams();
            List<TeamViewModel> teamVM = new List<TeamViewModel>();


            if (teamDM != null)
            {
                AutoMapper.Mapper.Map(teamDM, teamVM);
            }

            return teamVM;
        }
        public bool checkFirstEight(int teamId)
        {
            int counter = 0;
            List<PlayerDomainModel> teamList = teamBusiness.getPlayers(teamId);
            var arr = teamList.ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i].isPlaying == true)
                    counter++;
            }
            if (counter > 8)
                return false;
            else
                return true;
        }

        public string dummy()
        {
            return "ok";
        }
    }
}