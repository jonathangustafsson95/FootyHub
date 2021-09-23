using FootballMatchHub.Core.Models;
using FootballMatchHub.Core.Repositories;
using FootballMatchHub.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Persistence.Repositories
{
    public class FollowedGameRepository : IFollowedGameRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowedGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<PlayedGames> GetFollows(string userId)
        {
            return _context.PlayedGames
                            .Where(fg => fg.PlayerId == userId)
                            .ToList();
        }
    }
}