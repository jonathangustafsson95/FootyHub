using FootballMatchHub.Core;
using FootballMatchHub.Core.DTOs;
using FootballMatchHub.Core.Models;
using FootballMatchHub.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace FootballMatchHub.Controllers.API
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _uof;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
            _uof = new UnitOfWork(_context);
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_uof.Followings.GetIfFollowingPlayer(dto.FolloweeId, userId))
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _uof.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();

            var following = _uof.Followings.GetFollowing(userId, id);

            if (following == null)
                return NotFound();

            _context.Followings.Remove(following);
            _uof.Complete();
            return Ok(id);
        }
    }
}