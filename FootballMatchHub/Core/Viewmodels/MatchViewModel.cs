using FootballMatchHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Core.Viewmodels
{
    public class MatchViewModel
    {
        public IEnumerable<Match> PlayedMatches { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, PlayedGames> FollowedGames { get; set; }
    }
}