using System.ComponentModel.DataAnnotations;

namespace FootballMatchHub.Core.Models
{
    public class TypeOfGame
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}