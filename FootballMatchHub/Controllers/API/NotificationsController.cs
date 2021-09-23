using AutoMapper;
using FootballMatchHub.Core;
using FootballMatchHub.Core.DTOs;
using FootballMatchHub.Core.Models;
using FootballMatchHub.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballMatchHub.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _uof;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
            _uof = new UnitOfWork(_context);

        }
        public IEnumerable<NotificationDto> GetNewNotfications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _uof.UserNotifications.GetNewNotifications(userId);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<Match, MatchDto>();
                cfg.CreateMap<Notification, NotificationDto>();
            });
            IMapper mapper = config.CreateMapper();

            return notifications.Select(mapper.Map <Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _uof.UserNotifications.GetUnreadMessages(userId);

            _uof.UserNotifications.ReadMessages(notifications);

            _uof.Complete();

            return Ok();
        }
    }
}
