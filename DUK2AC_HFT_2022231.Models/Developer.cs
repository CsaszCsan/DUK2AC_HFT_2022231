using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Models
{
    [Table("Developers")]
    public class Developer:DataItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("dev_id", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [MaxLength(240)]
        public string Name { get; set; }

        [MaxLength(240)]
        public string Location { get; set; }


        public virtual ICollection<Game> GamesMade { get; set; }

        public Developer()
        {
            this.GamesMade = new HashSet<Game>();
        }

        public Developer(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
            
        }
    }
}
