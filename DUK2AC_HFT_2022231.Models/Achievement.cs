using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Models
{
    [Table("Achievements")]
    public class Achievement:DataItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ach_id", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [MaxLength(240)]
        public string Name { get; set; }

        [NotMapped]
        public virtual Game game { get; set; }
        [ForeignKey(nameof(game))]
        public int GameID { get; set; }
        
        public int? Bonuspoints { get; set; }

        public Achievement()
        {
        }

        public Achievement(int id, string name, int? bonuspoints)
        {
            Id = id;
            Name = name;
            Bonuspoints = bonuspoints;
        }
    }
}
