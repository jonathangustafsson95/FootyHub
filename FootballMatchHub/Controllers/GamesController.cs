using FootballMatchHub.Core.Models;
using FootballMatchHub.Core.Viewmodels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FootballMatchHub.Persistence;
using System.Security.Principal;

namespace FootballMatchHub.Controllers
{
    public class GamesController : Controller
    {
        private readonly IUnitOfWork _uof;

        public GamesController(IUnitOfWork iUoW)
        {
            _uof = iUoW;
        }

        public ActionResult Mine()
        {
            var games = _uof.Matches.GetUserMatches(User.Identity.GetUserId());

            return View(games);
        }

        public ActionResult Details(int id)
        {
            var game = _uof.Matches.GetMatchDetails(id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new MatchDetailsViewModel { Match= game };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending = _uof.PlayedGames.GetIfAttendingMatch(id, userId);

                viewModel.IsFollowing = _uof.Followings.GetIfFollowingPlayer(game.PlayerId, userId);

            }

            return View("Details", viewModel);
        }

        [Authorize]
        public ActionResult FollowedGames()
        {
            var viewModel = new MatchViewModel()
            {
                PlayedMatches = _uof.PlayedGames.GetMatchesUserFollows(User.Identity.GetUserId()),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Matches I'm following",
                FollowedGames = _uof.FollowedGames.GetFollows(User.Identity.GetUserId()).ToLookup(fg => fg.MatchId)
            };

            return View("Games", viewModel);
        }

        [HttpPost]
        public ActionResult Search(MatchViewModel vm)
        {
            return RedirectToAction("Index", "Home", new { query = vm.SearchTerm });
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MatchFormViewModel
            {
                TypeOfGames = _uof.TypeOfGames.GetTypesOfGames(),
                Heading = "Add a game"
            };
            return View("MatchForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatchFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.TypeOfGames = _uof.TypeOfGames.GetTypesOfGames();
                return View("MatchForm", vm); 
            }
            
            var game = new Match
            {
                PlayerId = User.Identity.GetUserId(),
                PlayerName = User.Identity.GetUserName(),
                Datetime = vm.GetDateTime(),
                TypeOfGameId = vm.TypeOfGame,
                HomeTeam = vm.HomeTeam,
                MatchSummary = vm.MatchSummary,
                Season = vm.Season,
                AwayTeam = vm.AwayTeam,
                Result = vm.Result,
                Goals = vm.Goals,
                Assists = vm.Assists,
                YCard = vm.YCard,
                RCard = vm.RCard,
                MinPlayed = vm.MinPlayed,
                PosPlayed = vm.PosPlayed
            };
            _uof.Matches.Add(game);
            _uof.Complete();
            return RedirectToAction("Mine", "Games");
        }

        public ActionResult Edit(int id)
        {
            var match = _uof.Matches.GetMatch(id);

            if (match == null)
                return HttpNotFound();

            if (match.PlayerId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var vm = new MatchFormViewModel
            {
                Id = match.Id,
                TypeOfGames = _uof.TypeOfGames.GetTypesOfGames(),
                Date = match.Datetime.ToString("d MMM yyyy"),
                Time = match.Datetime.ToString("HH:mm"),
                HomeTeam = match.HomeTeam,
                MatchSummary = match.MatchSummary,
                Season = match.Season,
                AwayTeam = match.AwayTeam,
                Result = match.Result,
                Goals = match.Goals,
                Assists = match.Assists,
                YCard = match.YCard,
                RCard = match.RCard,
                MinPlayed = match.MinPlayed,
                PosPlayed = match.PosPlayed,
                Heading = "Edit a game"
            };
            return View("MatchForm", vm);
        }

        public ActionResult Update(MatchFormViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                vm.TypeOfGames = _uof.TypeOfGames.GetTypesOfGames();
                return View("MatchForm", vm);
            }

            var match = _uof.Matches.GetMatchWithFollowers(vm.Id);

            if (match == null)
                return HttpNotFound();

            if (match.PlayerId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            match.Modify(vm);

            _uof.Complete();
            return RedirectToAction("Mine", "Games");
        }
    }
}