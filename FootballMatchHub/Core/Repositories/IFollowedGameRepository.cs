using FootballMatchHub.Core.Models;
using System.Collections.Generic;

namespace FootballMatchHub.Core.Repositories
{
    public interface IFollowedGameRepository
    {
        IEnumerable<PlayedGames> GetFollows(string userId);
    }
}