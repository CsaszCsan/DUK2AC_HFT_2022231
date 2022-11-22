using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Models
{
    [Table("Platforms")]
    class Platform:DataItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("plat_id", TypeName = "int")]
        public override int Id { get; set; }

        [Required]
        [MaxLength(240)]
        public string Name { get; set; }

        [MaxLength(240)]
        public int? Buy_Price { get; set; }



    }
}
