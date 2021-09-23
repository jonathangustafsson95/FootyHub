using FootballMatchHub.Core.Models;
using FootballMatchHub.Core.Repositories;
using FootballMatchHub.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Persistence.Repositories
{
    public class PlayedGameRepository : IPlayedGameRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayedGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool GetIfAttendingMatch(int id, string userId)
        {
            return _context.PlayedGames
                    .Any(a => a.MatchId == id && a.PlayerId == userId);
        }
        public PlayedGames GetFollowedMatchToDelete(int id, string userId)
        {
            return _context.PlayedGames
                    .SingleOrDefault(g => g.PlayerId == userId && g.MatchId == id);
        }

        public IEnumerable<Match> GetMatchesUserFollows(string userId)
        {
            return _context.PlayedGames
                .Where(a => a.PlayerId == userId)
                .Select(a => a.Match)
                .Include(g => g.Player)
                .Include(g => g.TypeOfGame)
                .ToList();
        }

    }
}