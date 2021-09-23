using FootballMatchHub.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Core.DTOs
{
    public class NotificationDto
    {
        public DateTime DateTime { get;  set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get;  set; }

        public string OriginalHomeTeam { get;  set; }

        public string OriginalAwayTeam { get;  set; }

        public string OriginalResult { get;  set; }

        public string OriginalMatchSummary { get;  set; }

        public int OriginalSeason { get;  set; }

        public int OriginalGoals { get;  set; }

        public int OriginalAssists { get;  set; }

        public int OriginalYCard { get;  set; }

        public int OriginalRCard { get;  set; }

        public int OriginalMinPlayed { get;  set; }

        public string OriginalPosPlayed { get;  set; }

        public TypeOfGame OriginalTypeOfGame { get;  set; }

        public MatchDto Match { get; set; }
    }
}