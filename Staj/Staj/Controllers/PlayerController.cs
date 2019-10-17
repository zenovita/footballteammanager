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
    public class PlayerController : Controller
    {

        IPlayerBusiness playerBusiness;
        ITeamBusiness teamBusiness;
        IPlayerSkillBusiness playerSkillBusiness;

        public PlayerController(IPlayerBusiness _playerBusiness, ITeamBusiness _teamBusiness, IPlayerSkillBusiness _playerSkillBusiness)
        {
            playerBusiness = _playerBusiness;
            teamBusiness = _teamBusiness;
            playerSkillBusiness = _playerSkillBusiness;
        }

        public ActionResult Index()
        {
            /*var result = AddEditPlayer();
            var result2 = AddEditPlayer();

            var result3 = DeletePlayer(7);

            ViewBag.PlayerName = playerBusiness.getPlayerName(15);
            List<PlayerDomainModel> dm = playerBusiness.GetAllPlayers();
            List<PlayerViewModel> vm = new List<PlayerViewModel>();*/


            ViewBag.TeamList = new SelectList(getTeamVM(), "teamId", "teamName");

            /*AutoMapper.Mapper.Map(dm, vm);
            ViewBag.PlayerList = vm;*/
            return View();
        }
        [HttpPost]
        public string AddEditPlayer(PlayerSkillRelationViewModel vm)
        {
            //PlayerViewModel vm = new PlayerViewModel();
            string result = "";

            //vm.playerId = 5;
            //vm.playerName = "Testasdasd123123";
            //vm.position = "GK";
            //vm.skill = 5;
            //vm.teamId = 2;

            PlayerDomainModel dm = new PlayerDomainModel();
            PlayerSkillsDomainModel skillDM = new PlayerSkillsDomainModel();

            AutoMapper.Mapper.Map(vm.SkillVM, skillDM);
            int skillID = playerSkillBusiness.AddUpdatePlayerSkill(skillDM);

            AutoMapper.Mapper.Map(vm.PlayerVM, dm);
            result = result + " " + playerBusiness.AddUpdatePlayer(dm, skillID);

            return result;
        }
        public ActionResult GetPlayer(int playerId)
        {
            PlayerDomainModel pDM = playerBusiness.getPlayer(playerId);
            PlayerSkillsDomainModel sDM = playerSkillBusiness.getPlayerSkills(pDM.skill);
            PlayerSkillRelationViewModel result = new PlayerSkillRelationViewModel();

            PlayerViewModel pVM = new PlayerViewModel();
            PlayerSkillViewModel sVM = new PlayerSkillViewModel();

            AutoMapper.Mapper.Map(pDM, pVM);
            AutoMapper.Mapper.Map(sDM, sVM);

            result.PlayerVM = pVM;
            result.SkillVM = sVM;

            ViewBag.TeamList = new SelectList(getTeamVM(), "teamId", "teamName");
            ViewBag.playerId = playerId;

            return PartialView("EditPlayerPartial", result);
        }
        public string DeletePlayer(int pId)
        {
            string result = playerBusiness.DeletePlayer(pId);
            ViewBag.TeamList = new SelectList(getTeamVM(), "teamId", "teamName");
            ViewBag.playerId = pId;
            return result;
        }

        public ActionResult DeletePlayerPrompt(int pId)
        {
            ViewBag.TeamList = new SelectList(getTeamVM(), "teamId", "teamName");
            ViewBag.playerId = pId;
            return PartialView("DeletePlayerPartial");
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

        public ActionResult ShowPlayers()
        {
            ViewBag.TeamList = new SelectList(getTeamVM(), "teamId", "teamName");
            return View();
        }
        public JsonResult ShowPlayer()
        {
            ViewBag.TeamList = new SelectList(getTeamVM(), "teamId", "teamName");
            List<PlayerViewModel> list = getPlayerVM();


            // construction
            var test = list.ToArray();
            List<PlayerSkillRelationViewModel> result = new List<PlayerSkillRelationViewModel>();
            for (int i = 0; i < test.Length; i++)
            {
                PlayerSkillRelationViewModel vm = new PlayerSkillRelationViewModel();
                PlayerSkillViewModel svm;
                PlayerSkillsDomainModel dm;
                if (test[i].skill != 0)
                {
                    dm = playerSkillBusiness.getPlayerSkills(test[i].skill);
                    svm = new PlayerSkillViewModel();
                    AutoMapper.Mapper.Map(dm, svm);
                    vm.SkillVM = svm;
                }
                else
                {
                    dm = null;
                    svm = null;
                    vm.SkillVM = null;
                }

                vm.PlayerVM = test[i];
                vm.teamName = teamBusiness.getTeamName(vm.PlayerVM.teamId);
                result.Add(vm);
            }


            // construction

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<PlayerViewModel> getPlayerVM()
        {
            List<PlayerViewModel> playerVM = new List<PlayerViewModel>();
            List<PlayerDomainModel> playerDM = playerBusiness.GetAllPlayers();


            if (playerDM != null)
            {
                AutoMapper.Mapper.Map(playerDM, playerVM);
            }

            return playerVM;
        }

        public List<PlayerSkillViewModel> getPlayerSkillVM()
        {
            List<PlayerSkillViewModel> svm = new List<PlayerSkillViewModel>();
            List<PlayerSkillsDomainModel> sdm = playerSkillBusiness.getAllSkills();


            if (svm != null)
            {
                AutoMapper.Mapper.Map(sdm, svm);
            }

            return svm;
        }
    }
}