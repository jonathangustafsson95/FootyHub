using FootballMatchHub.Core;
using FootballMatchHub.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballMatchHub.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _uof;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
            _uof = new UnitOfWork(_context);
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _uof.Followings.GetFollowees(userId);

            return View(artists);
        }
    }
}