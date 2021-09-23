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
    public class UserNotificationsRepository : IUserNotificationsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserNotification> GetUnreadMessages(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }

        public void ReadMessages(List<UserNotification> notifications)
        {
            notifications.ForEach(n => n.Read());
        }

        public List<Notification> GetNewNotifications(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Match.Player)
                .ToList();
        }
    }
}