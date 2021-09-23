using FootballMatchHub.Core.Models;
using FootballMatchHub.Core.Repositories;
using FootballMatchHub.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Persistence.Repositories
{
    public class FollowingsRepository : IFollowingsRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool GetIfFollowingPlayer(string playerId, string userId)
        {
            return _context.Followings
                    .Any(f => f.FolloweeId == playerId && f.FollowerId == userId);
        }

        public Following GetFollowing(string userId, string playerId)
        {
            return _context.Followings
                .SingleOrDefault(g => g.FollowerId == userId && g.FolloweeId == playerId);
        }
        public List<ApplicationUser> GetFollowees(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }
    }
}