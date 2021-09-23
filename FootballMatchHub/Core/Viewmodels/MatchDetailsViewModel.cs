using FootballMatchHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Core.Viewmodels
{
    public class MatchDetailsViewModel
    {
        public Match Match { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}