using FootballMatchHub.Core.Models;
using System.Collections.Generic;

namespace FootballMatchHub.Core.Repositories
{
    public interface IFollowingsRepository
    {
        List<ApplicationUser> GetFollowees(string userId);
        Following GetFollowing(string userId, string playerId);
        bool GetIfFollowingPlayer(string playerId, string userId);
    }
}