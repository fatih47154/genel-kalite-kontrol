using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities.Abstract;

namespace KaliteGiris.Entities
{
    [Table("Role")]
    public class Role : ABaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RolId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Rol Adı")]
        public string RolName { get; set; }
    }
}
