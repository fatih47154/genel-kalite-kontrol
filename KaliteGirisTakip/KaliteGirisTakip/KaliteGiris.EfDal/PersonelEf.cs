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
    public class PersonelEf : IPersonelEf
    {
        public int PersonelEkle(Personel personel)
        {
            int sonuc = 0;
            try
            {
                LabDataModel dataModel = new LabDataModel();
                dataModel.Personel.Add(personel);
                sonuc = dataModel.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return sonuc;
        }

        public int PersonelGuncelle(Personel personel)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                context.Entry(personel).State = EntityState.Modified;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;
        }

        public List<Personel> PersonelListele()
        {
            List<Personel> PersonelList = null;
            try
            {
                LabDataModel dataModel = new LabDataModel();
                PersonelList = dataModel.Personel.ToList();
                var result = PersonelList.Where(e => e.PersonelId != null).ToList();
                PersonelList = result;
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }
            return PersonelList;
        }

        public int PersonelSil(Personel personel)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                context.Entry(personel).State = EntityState.Deleted;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;
        }
    }
    
}
