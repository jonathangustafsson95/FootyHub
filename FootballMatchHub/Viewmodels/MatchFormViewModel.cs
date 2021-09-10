using FootballMatchHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Viewmodels
{
    public class MatchFormViewModel
    {
        public string Date { get; set; }
        
        public string Time { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Result { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        public int YCard { get; set; }

        public int RCard { get; set; }

        public int MinPlayed { get; set; }

        public string PosPlayed { get; set; }

        public byte TypeOfGame { get; set; }

        public IEnumerable<TypeOfGame> TypeOfGames { get; set; }

    }
}