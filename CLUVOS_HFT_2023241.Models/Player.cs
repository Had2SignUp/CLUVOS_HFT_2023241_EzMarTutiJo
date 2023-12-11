using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUVOS_HFT_2023241.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool RightFooted { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set;}
        [NotMapped]
        public virtual Team Team { get; set; }

        public Player()
        {
        }
        public Player(int id, string name, int age, bool rightFooted, int salary, string position, int teamId)
        {
            Id = id;
            Name = name;
            Age = age;
            RightFooted = rightFooted;
            Salary = salary;
            Position = position;
            TeamId = teamId;
        }
    }
}
