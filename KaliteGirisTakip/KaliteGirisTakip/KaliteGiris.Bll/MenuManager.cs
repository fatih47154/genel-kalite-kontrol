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
    public class MenuManager : IMenuEf
    {
        IMenuEf MenuEf { get; set; }

        public MenuManager()
        {
            MenuEf = new MenuEf();
        }
        public List<NavigationMenu> MenuListele()
        {
            return MenuEf.MenuListele();
        }
    }
}
