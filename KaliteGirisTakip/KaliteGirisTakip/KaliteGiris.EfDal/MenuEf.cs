using KaliteGiris.EfDal;
using KaliteGiris.Entities;
using KaliteGiris.IEfDal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.EfDal
{
    public class MenuEf : IMenuEf
    {
        NavigationMenu NavigationMenu { get; set; }

        public List<NavigationMenu> MenuListele()
        {
            List<NavigationMenu>MenuList = null;
            try
            {
                LabDataModel dataModel = new LabDataModel();
                MenuList = dataModel.NavigationMenu.ToList();
                var result = MenuList.Where(e => e.MenuId != null).ToList();
                MenuList = result;
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }
            return MenuList;
        }
        
    }
}
