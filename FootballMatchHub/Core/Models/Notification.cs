using System;
using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Core.Models
{
    public class Notification {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalHomeTeam { get; private set; }

        public string OriginalAwayTeam { get; private set; }

        public string OriginalResult { get; private set; }

        public string OriginalMatchSummary { get; private set; }

        public int OriginalSeason { get; private set; }

        public int OriginalGoals { get; private set; }

        public int OriginalAssists { get; private set; }

        public int OriginalYCard { get; private set; }

        public int OriginalRCard { get; private set; }

        public int OriginalMinPlayed { get; private set; }

        public string OriginalPosPlayed { get; private set; }

        public TypeOfGame OriginalTypeOfGame{ get; private set; }

        [Required]
        public Match Match { get; set; }

        protected Notification()
        {

        }

        private Notification(NotificationType type, Match match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            Type = type;
            Match = match;
            DateTime = DateTime.Now;
        }

        public static Notification GameCreated(Match game)
        {
            return new Notification(NotificationType.GameCreated, game);
        }

        public static Notification GameUpdated(Match newGame)
        {
            var notification = new Notification(NotificationType.GameUpdated, newGame);

            notification.OriginalDateTime = newGame.Datetime;
            notification.OriginalHomeTeam = newGame.HomeTeam;
            notification.OriginalAwayTeam = newGame.AwayTeam;
            notification.OriginalResult = newGame.Result;
            notification.OriginalMatchSummary = newGame.MatchSummary;
            notification.OriginalSeason = newGame.Season;
            notification.OriginalGoals = newGame.Goals;
            notification.OriginalAssists = newGame.Assists;
            notification.OriginalYCard = newGame.YCard;
            notification.OriginalRCard = newGame.RCard;
            notification.OriginalMinPlayed = newGame.MinPlayed;
            notification.OriginalPosPlayed = newGame.PosPlayed;
            notification.OriginalTypeOfGame = newGame.TypeOfGame;

            return notification;
        }

        public static Notification GameCanceled(Match game)
        {
            return new Notification(NotificationType.GameCanceled, game);
        }

       
    }
}