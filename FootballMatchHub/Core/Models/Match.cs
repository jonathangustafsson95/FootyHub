using FootballMatchHub.Core.Viewmodels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FootballMatchHub.Core.Models
{
    public class Match
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Player { get; set; }

        public string PlayerId { get; set; }

        public string PlayerName { get; set; }

        public DateTime Datetime { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Result { get; set; }

        public string MatchSummary { get; set; }

        public int Season { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        public int YCard { get; set; }

        public int RCard { get; set; }

        public int MinPlayed { get; set; }

        public string PosPlayed { get; set; }

        public TypeOfGame TypeOfGame { get; set; }

        public byte TypeOfGameId { get; set; }

        public ICollection<PlayedGames> PlayersFollowing { get; private set; }

        public Match()
        {
            PlayersFollowing = new Collection<PlayedGames>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification =  Notification.GameCanceled(this);

            foreach (var user in PlayersFollowing.Select(u => u.Player))
            {
                user.Notify(notification);
            }
        }

        public void Modify(MatchFormViewModel vm)
        {
            var notification =  Notification.GameUpdated(this);

            HomeTeam = vm.HomeTeam;
            AwayTeam = vm.AwayTeam;
            MatchSummary = vm.MatchSummary;
            Season = vm.Season;
            Result = vm.Result;
            Goals = vm.Goals;
            Assists = vm.Assists;
            YCard = vm.YCard;
            RCard = vm.RCard;
            MinPlayed = vm.MinPlayed;
            PosPlayed = vm.PosPlayed;


            foreach (var user in PlayersFollowing.Select(u => u.Player))
            {
                user.Notify(notification);
            }
        }
    }
}