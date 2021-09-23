using FootballMatchHub.Core;
using FootballMatchHub.Core.DTOs;
using FootballMatchHub.Core.Models;
using FootballMatchHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace FootballMatchHub.Controllers.API
{
    [Authorize]
    public class PlayedGamesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _uof;

        public PlayedGamesController()
        {
            _context = new ApplicationDbContext();
            _uof = new UnitOfWork(_context);
        }

        [HttpPost]
        public IHttpActionResult FollowGame(PlayedGameDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_uof.PlayedGames.GetIfAttendingMatch(dto.MatchId, userId))
            {
                return BadRequest("You are already following this game.");
            }

            var playedGame = new PlayedGames
            {
                MatchId = dto.MatchId,
                PlayerId = userId
            };
            _context.PlayedGames.Add(playedGame);
            _uof.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var playedGame = _uof.PlayedGames.GetFollowedMatchToDelete(id, userId);

            if (playedGame == null)
                return NotFound();

            _context.PlayedGames.Remove(playedGame);
            _uof.Complete();
            return Ok(id);
        }
    }
}
