using KaliteGiris.IEfDal;
using KaliteGiris.EfDal;
using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KaliteGiris.EfDal
{
    public class DurumTipiEf : IDurumTipiEf
    {
        DurumTipi DurumTipi { get; set; }

        public List<DurumTipi> DurumTipiListele()
        {
            List<DurumTipi> DurumTipiList = null;

            try
            {
                LabDataModel dataModel = new LabDataModel();
                DurumTipiList = dataModel.DurumTipi.ToList();
                var result = DurumTipiList.Where(e => e.DurumTipiId != null && e.IsActive == true).ToList();
                DurumTipiList = result;
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }
            return DurumTipiList;
        }

        public int DurumTipiEkle(DurumTipi durumTipi)
        {
            int sonuc = 0;
            try
            {
                string date = DateTime.Now.ToString();
                durumTipi.CreatedDate = Convert.ToDateTime(date);
                durumTipi.IsActive = true;
                LabDataModel dataModel = new LabDataModel();
                dataModel.DurumTipi.Add(durumTipi);
                sonuc = dataModel.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return sonuc;
        }

        public int DurumTipiGuncelle(DurumTipi durumTipi)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                string date = DateTime.Now.ToString();
                durumTipi.UpdatededDate = Convert.ToDateTime(date);
                context.Entry(durumTipi).State = EntityState.Modified;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;
        }
        public int DurumTipiSil(Guid id)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                DurumTipi durumTipi = context.DurumTipi.FirstOrDefault(x => x.DurumTipiId == id);
                Durum veri = context.Durum.FirstOrDefault(x => x.DurumTipiId == id);
                if (veri == null)
                {
                    durumTipi.IsActive = false;
                    context.SaveChanges();
                    sonuc = 1;
                }
                else if (veri != null)
                {
                    sonuc = 2;
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
