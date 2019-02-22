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
    [Table("NavigationMenus")]
    public class NavigationMenu : ABaseEntity
    {
        public NavigationMenu()
        {
            NavigationMenuRoles = new List<NavigationMenuRole>();
            //TreeMenuModuler = new HashSet<MenuModul>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Menu Id")]
        public Guid MenuId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Menu Adı")]
        public string MenuName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Menu Linki")]
        public string MenuLink { get; set; }

        [Required]
        [Display(Name = "Menu Sıra")]
        public int MenuSira { get; set; }

        [StringLength(50)]
        public string IconName { get; set; }

        [Display(Name = "Parent Menu Id")]
        public Guid? ParentMenuId { get; set; }
        [ForeignKey("ParentMenuId")]
        public virtual NavigationMenu Parent { get; set; }
        public virtual ICollection<NavigationMenu> Children { get; set; }

        [StringLength(30)]
        public string Controler { get; set; }

        [StringLength(30)]
        [DataType(DataType.Text)]
        public string Action { get; set; }

        [StringLength(50)]
        public string QuickAccessIcon { get; set; }

        public bool QuickAccess { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
        "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<NavigationMenuRole> NavigationMenuRoles { get; set; }


        public NavigationMenu TreeMenuCopy()
        {
            return new NavigationMenu
            {
                ParentMenuId = ParentMenuId,
                MenuId = MenuId,
                MenuSira = MenuSira,
                QuickAccess = QuickAccess,
                Action = Action,
                MenuName = MenuName,
                IsActive = IsActive,
                IconName = IconName,
                Controler = Controler,
            };
        }

    }
}
