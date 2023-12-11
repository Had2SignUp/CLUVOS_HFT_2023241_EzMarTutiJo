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
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public bool HasVar { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }

        public League()
        {
        }

        public League(int id, string Name, string country, bool HasVar)
        {
            Id = id;
            Name = Name;
            Country = country;
            HasVar = HasVar;
        }
    }
    public class YouthSquadInfo
    {
        public YouthSquadInfo()
        {
        }
        public int LeagueId { get; set; }
        public int YouthSquadsInLeague { get; set; }

        public YouthSquadInfo(int id, int youthSquadsInLeague)
        {
            LeagueId = id;
            YouthSquadsInLeague = youthSquadsInLeague;
        }
    }

}
