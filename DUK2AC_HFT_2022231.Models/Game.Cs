using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Models
{
    [Table("Games")]
    class Game:DataItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("game_id", TypeName = "int")]
        public override int Id { get; set; }

        [MaxLength(240)]
        [Required]
        [Column("game_name")]
        public string Title { get; set; }

        [Required]
        public int Price { get; set; }

        [NotMapped]
        public virtual Developer Developer { get; set; }

        [ForeignKey(nameof(Developer))]
        public int DevID { get; set; }

        [NotMapped]
        public virtual Platform Platform { get; set; }

        [ForeignKey(nameof(Platform))]
        public int PlatID { get; set; }
    }
}
