using FootballMatchHub.Core.Models;
using System.Data.Entity;

namespace FootballMatchHub.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Following> Followings { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<PlayedGames> PlayedGames { get; set; }
        DbSet<TypeOfGame> TypesOfGame { get; set; }
        DbSet<UserNotification> UserNotifications { get; set; }
    }
}