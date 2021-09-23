using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FootballMatchHub.Persistence;
using FootballMatchHub.Core;

namespace FootballMatchHub.Controllers.API
{
    [Authorize]
    public class MatchesController : ApiController
    {
        private readonly IUnitOfWork _uof;

        public MatchesController(IUnitOfWork iUoW)
        {
            _uof = iUoW;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var game = _uof.Matches.GetMatchToCancel(id, userId);

            if (game.IsCanceled || game == null)
            {
                return NotFound();
            }

            game.Cancel();

            _uof.Complete();
            return Ok();
        }
    }
}
