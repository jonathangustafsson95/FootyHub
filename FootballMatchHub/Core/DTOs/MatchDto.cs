using System;


namespace FootballMatchHub.Core.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public bool IsCanceled { get;  set; }
        public UserDto Player { get; set; }
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
        public TypeOfGameDto TypeOfGame { get; set; }
    }
}