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
    public class RepoController : Controller
    {

        IPlayerBusiness playerBusiness;

        public RepoController(IPlayerBusiness _playerBusiness)
        {
            playerBusiness = _playerBusiness;
        }

        public ActionResult Index()
        {
            var result = AddEditPlayer();
            var result2 = AddEditPlayer();

            var result3 = DeletePlayer(7);
            
            ViewBag.PlayerName = playerBusiness.getPlayerName(15);
            List<PlayerDomainModel> dm = playerBusiness.GetAllPlayers();
            List <PlayerViewModel> vm = new List<PlayerViewModel>();

            

            AutoMapper.Mapper.Map(dm, vm);
            ViewBag.PlayerList = vm;
            return View();
        }

        public string AddEditPlayer()
        {
            PlayerViewModel vm = new PlayerViewModel();
            string result = "";

            //vm.playerId = 5;
            vm.playerName = "Testasdasd123123";
            vm.position = "GK";
            vm.skill = 5;
            vm.teamId = 2;

            PlayerDomainModel dm = new PlayerDomainModel();

            AutoMapper.Mapper.Map(vm, dm);
            //result = playerBusiness.AddUpdatePlayer(dm);

            return result;
        }

        public string DeletePlayer(int pId)
        {
            string result = playerBusiness.DeletePlayer(pId);
            return result;
        }
    }
}