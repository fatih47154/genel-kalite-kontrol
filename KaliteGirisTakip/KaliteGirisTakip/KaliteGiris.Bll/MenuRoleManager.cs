using KaliteGiris.Entities;
using KaliteGiris.IEfDal;
using KaliteGiris.EfDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.Bll
{
    public class MenuRoleManager : IMenuRoleEf
    {
        IMenuRoleEf MenuRoleEf { get; set; }

        public MenuRoleManager()
        {
            MenuRoleEf = new MenuRoleEf();
        }
        public List<NavigationMenuRole> MenuRoleListele()
        {
            return MenuRoleEf.MenuRoleListele();
        }

        public int RolAta(NavigationMenuRole veri)
        {
            int sonuc = 0;
            sonuc = MenuRoleEf.RolAta(veri);

            return sonuc;
        }

        public int MenuRoleDuzenle(NavigationMenuRole veri)
        {
            int sonuc = 0;
            sonuc = MenuRoleEf.MenuRoleDuzenle(veri);
            return sonuc;
        }

        public int MenuRoleSil(Guid id)
        {
            int sonuc = 0;
            sonuc = MenuRoleEf.MenuRoleSil(id);

            return sonuc;
        }


    }
}
