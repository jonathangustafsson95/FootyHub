using FootballMatchHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace FootballMatchHub.Persistence.EnitityConfigurations
{
    public class MatchConfig : EntityTypeConfiguration<Match>
    {
        public MatchConfig()
        {
            Property(m => m.PlayerId)
                .IsRequired();

            Property(m => m.PlayerName)
                .IsRequired();

            Property(m => m.HomeTeam)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.AwayTeam)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.Result)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.MatchSummary)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.Season)
                 .IsRequired();

            Property(m => m.PosPlayed)
                .HasMaxLength(255);

            Property(m => m.TypeOfGameId)
                .IsRequired();

            HasMany(m => m.PlayersFollowing)
                .WithRequired(m => m.Match)
                .WillCascadeOnDelete(false);

        }
    }
}