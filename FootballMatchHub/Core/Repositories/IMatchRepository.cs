using FootballMatchHub.Core.Models;
using System.Collections.Generic;

namespace FootballMatchHub.Core.Repositories
{
    public interface IMatchRepository
    {
        void Add(Match match);
        IEnumerable<Match> GetAllGames();
        Match GetMatch(int matchId);
        Match GetMatchDetails(int matchId);
        Match GetMatchToCancel(int id, string userId);
        Match GetMatchWithFollowers(int matchId);
        IEnumerable<Match> GetUserMatches(string userId);
    }
}