using FootballMatchHub.Core.Models;
using System.Collections.Generic;

namespace FootballMatchHub.Core.Repositories
{
    public interface IPlayedGameRepository
    {
        PlayedGames GetFollowedMatchToDelete(int id, string userId);
        bool GetIfAttendingMatch(int id, string userId);
        IEnumerable<Match> GetMatchesUserFollows(string userId);
    }
}