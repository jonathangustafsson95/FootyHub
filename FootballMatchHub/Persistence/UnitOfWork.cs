using FootballMatchHub.Persistence;
using FootballMatchHub.Core.Repositories;
using FootballMatchHub.Persistence.Repositories;

namespace FootballMatchHub.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMatchRepository Matches { get; private set; }
        public IFollowingsRepository Followings { get; private set; }
        public IFollowedGameRepository FollowedGames { get; private set; }
        public IPlayedGameRepository PlayedGames { get; private set; }
        public ITypeOfGameRepository TypeOfGames { get; private set; }
        public IUserNotificationsRepository UserNotifications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Matches = new MatchRepository(context);
            Followings = new FollowingsRepository(context);
            FollowedGames = new FollowedGameRepository(context);
            PlayedGames = new PlayedGameRepository(context);
            TypeOfGames = new TypeOfGameRepository(context);
            UserNotifications = new UserNotificationsRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}