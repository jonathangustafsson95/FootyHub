using FootballMatchHub.Core.Models;
using System.Collections.Generic;

namespace FootballMatchHub.Core.Repositories
{
    public interface IUserNotificationsRepository
    {
        List<Notification> GetNewNotifications(string userId);
        List<UserNotification> GetUnreadMessages(string userId);
        void ReadMessages(List<UserNotification> notifications);
    }
}