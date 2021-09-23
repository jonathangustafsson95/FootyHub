using FootballMatchHub.Controllers;
using FootballMatchHub.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace FootballMatchHub.Core.Viewmodels
{
    public class MatchFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [NotFutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        [Required]
        public string Result { get; set; }

        [Required]
        [StringLength(255)]
        public string MatchSummary { get; set; }

        [Required]
        public int Season { get; set; }

        [Required]
        public int Goals { get; set; }

        [Required]
        public int Assists { get; set; }

        [Required]
        public int YCard { get; set; }

        [Required]
        public int RCard { get; set; }

        [Required]
        public int MinPlayed { get; set; }

        [Required]
        public string PosPlayed { get; set; }

        [Required]
        public byte TypeOfGame { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GamesController, ActionResult>> update = (c => c.Update(this));

                Expression<Func<GamesController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public IEnumerable<TypeOfGame> TypeOfGames { get; set; }

        public DateTime GetDateTime() { return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }

    }
}