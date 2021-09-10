using FootballMatchHub.Models;
using FootballMatchHub.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballMatchHub.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Games
        public ActionResult Create()
        {
            var viewModel = new MatchFormViewModel
            { 
                TypeOfGames = _context.TypesOfGame.ToList()
            };
            return View(viewModel);
        }
    }
}