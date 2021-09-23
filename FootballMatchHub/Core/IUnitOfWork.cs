using FootballMatchHub.Core;
using FootballMatchHub.Core.Repositories;

namespace FootballMatchHub.Persistence
{
    public interface IUnitOfWork
    {
        IFollowedGameRepository FollowedGames { get; }
        IFollowingsRepository Followings { get; }
        IMatchRepository Matches { get; }
        IPlayedGameRepository PlayedGames { get; }
        ITypeOfGameRepository TypeOfGames { get; }
        IUserNotificationsRepository UserNotifications { get; }

        void Complete();
    }
}