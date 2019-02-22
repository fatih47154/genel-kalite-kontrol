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
    [Table("NavigationMenuRoles")]
    public class NavigationMenuRole : ABaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MenuRolId { get; set; }

        [Required]
        public Guid MenuId { get; set; }
        [Required]
        public Guid RolId { get; set; }

        public virtual Role Rol { get; set; }
        public virtual NavigationMenu NavigationMenu { get; set; }

    }
}
