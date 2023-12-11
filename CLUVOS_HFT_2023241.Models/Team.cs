using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLUVOS_HFT_2023241.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(League))]
        public int LeagueId { get; set; }
        public bool HasYoungLeagueTeam { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual League League { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }

        public Team()
        {
        }
        public Team(int id, string name, int leagueId, bool HasYoungLeagueTeam)
        {
            Id = id;
            Name = name;
            LeagueId = leagueId;
            HasYoungLeagueTeam = HasYoungLeagueTeam;
        }
    }
}
