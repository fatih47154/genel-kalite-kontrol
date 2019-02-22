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
    public class MenuRoleEf : IMenuRoleEf
    {
        NavigationMenuRole NavigationMenuRole { get; set; }

        public List<NavigationMenuRole> MenuRoleListele()
        {
            List<NavigationMenuRole> MenuRoleList = null;
            try
            {
                LabDataModel dataModel = new LabDataModel();
                MenuRoleList = dataModel.NavigationMenuRole.ToList();
                var result = MenuRoleList.Where(e => e.MenuRolId != null && e.IsActive == true).ToList();
                MenuRoleList = result;
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }
            return MenuRoleList;
        }

        public int RolAta(NavigationMenuRole veri)
        {
            int sonuc = 0;
            try
            {
                veri.IsActive = true;
                string date = DateTime.Now.ToString();
                veri.CreatedDate = Convert.ToDateTime(date);

                LabDataModel dataModel = new LabDataModel();
                dataModel.NavigationMenuRole.Add(veri);
                sonuc = dataModel.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return sonuc;
        }

        public int MenuRoleDuzenle(NavigationMenuRole veri)
        {
            string date = DateTime.Now.ToString();
            veri.UpdatededDate = Convert.ToDateTime(date);
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                context.Entry(veri).State = EntityState.Modified;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;
        }

        public int MenuRoleSil(Guid id)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                NavigationMenuRole veri = context.NavigationMenuRole.FirstOrDefault(x => x.MenuRolId == id);
                if (veri != null)
                {
                    veri.IsActive = false;
                    context.SaveChanges();
                    sonuc = 1;
                }
                else
                {
                    sonuc = 0;
                }
            }
            return sonuc;
        }

    }
}
