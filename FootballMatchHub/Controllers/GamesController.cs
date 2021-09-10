using FootballMatchHub.Models;
using FootballMatchHub.Viewmodels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballMatchHub.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MatchFormViewModel
            {
                TypeOfGames = _context.TypesOfGame.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(MatchFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.TypeOfGames = _context.TypesOfGame.ToList();
                return View("Create", vm); 
            }
            
            var game = new Match
            {
                PlayerId = User.Identity.GetUserId(),
                Datetime = vm.GetDateTime(),
                TypeOfGameId = vm.TypeOfGame,
                HomeTeam = vm.HomeTeam,
                AwayTeam = vm.AwayTeam,
                Result = vm.Result,
                Goals = vm.Goals,
                Assists = vm.Assists,
                YCard = vm.YCard,
                RCard = vm.RCard,
                MinPlayed = vm.MinPlayed,
                PosPlayed = vm.PosPlayed
            };
            _context.Matches.Add(game);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}