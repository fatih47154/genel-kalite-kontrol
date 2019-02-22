using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.IEfDal
{
    public interface IMenuRoleEf
    {
        List<NavigationMenuRole> MenuRoleListele();
        int RolAta(NavigationMenuRole NavigationMenuRole);
        int MenuRoleDuzenle(NavigationMenuRole veri);
        int MenuRoleSil(Guid id);
    }
}
