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
    public class MatchRepository : IMatchRepository
    {
        private readonly IApplicationDbContext _context;

        public MatchRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Match GetMatchWithFollowers(int matchId)
        {
            return _context.Matches
                .Include(m => m.PlayersFollowing.Select(p => p.Player))
                .SingleOrDefault(m => m.Id == matchId);
        }

        public Match GetMatch(int matchId)
        {
            return _context.Matches.Single(m => m.Id == matchId);
        }

        public Match GetMatchDetails(int matchId)
        {
            return _context.Matches
                .Include(g => g.TypeOfGame)
                .Include(g => g.Player)
                .SingleOrDefault(g => g.Id == matchId);
        }

        public IEnumerable<Match> GetUserMatches(string userId)
        {
            return _context.Matches
                .Where(g => g.PlayerId == userId && !g.IsCanceled)
                .Include(g => g.TypeOfGame)
                .Include(g => g.Player)
                .ToList();
        }

        public IEnumerable<Match> GetAllGames()
        {
            return _context.Matches
                .Include(m => m.Player)
                .Include(m => m.TypeOfGame)
                .Where(m => m.Datetime < DateTime.Now && !m.IsCanceled);
        }

        public Match GetMatchToCancel(int id, string userId)
        {
            return _context.Matches
                .Include(p => p.PlayersFollowing.Select(u => u.Player))
                .Single(g => g.Id == id && g.PlayerId == userId);
        }

        public void Add(Match match)
        {
            _context.Matches.Add(match);
        }
    }
}