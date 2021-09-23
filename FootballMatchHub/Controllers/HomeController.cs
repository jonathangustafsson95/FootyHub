using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FootballMatchHub.Persistence;
using FootballMatchHub.Core.Viewmodels;
using FootballMatchHub.Core;

namespace FootballMatchHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _uof;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _uof = new UnitOfWork(_context);
        }

        public ActionResult Index(string query = null)
        {
            var playedMatches = _uof.Matches.GetAllGames();

            if (!String.IsNullOrWhiteSpace(query))
            {
                playedMatches = playedMatches
                .Where(m => m.Player.Name.Contains(query) ||
                m.MatchSummary.Contains(query) ||
                m.HomeTeam.Contains(query) ||
                m.AwayTeam.Contains(query) ||
                m.PosPlayed.Contains(query) ||
                m.Season.ToString().Contains(query));
            }

            var viewModel = new MatchViewModel
            {
                PlayedMatches = playedMatches,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Games from all players",
                SearchTerm = query,
                FollowedGames = _uof.FollowedGames.GetFollows(User.Identity.GetUserId()).ToLookup(fg => fg.MatchId)
            };

            return View("Games", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}