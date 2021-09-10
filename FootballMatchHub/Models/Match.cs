using System;
using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Models
{
    public class Match
    {
        public int Id { get; set; }

        public ApplicationUser Player { get; set; }

        [Required]
        public string PlayerId { get; set; }

        public DateTime Datetime { get; set; }

        [Required]
        [StringLength(255)]
        public string HomeTeam { get; set; }

        [Required]
        [StringLength(255)]
        public string AwayTeam { get; set; }

        [Required]
        [StringLength(255)]
        public string Result { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        public int YCard { get; set; }

        public int RCard { get; set; }

        public int MinPlayed { get; set; }

        [StringLength(255)]
        public string PosPlayed { get; set; }

        public TypeOfGame TypeOfGame { get; set; }

        [Required]
        public byte TypeOfGameId { get; set; }
    }
}