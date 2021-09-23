using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Core.Models
{
    public class PlayedGames
    {
        public Match Match { get; set; }
        public ApplicationUser Player { get; set; }

        [Key]
        [Column(Order=1)]
        public int MatchId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string PlayerId { get; set; }
    }
}