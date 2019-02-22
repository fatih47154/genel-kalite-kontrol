using KaliteGiris.IEfDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities;
using System.Data.Entity;

namespace KaliteGiris.EfDal
{
    public class DurumEf : IDurumEf
    {
        Durum Durum { get; set; }
       
        public int DurumEkle(Durum durum)
        {
            int sonuc = 0;
            try
            {
                durum.IsActive = true;
                string date = DateTime.Now.ToString();
                durum.CreatedDate = Convert.ToDateTime(date);

                LabDataModel dataModel = new LabDataModel();
                dataModel.Durum.Add(durum);
                sonuc = dataModel.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return sonuc;
        }

        public int DurumGuncelle(Durum durum)
        {
            string date = DateTime.Now.ToString();
            durum.UpdatededDate = Convert.ToDateTime(date);
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                context.Entry(durum).State = EntityState.Modified;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;
        }

        public List<Durum> DurumListele()
        {
            List<Durum> DurumList = new List<Durum>();
                        
            try
            {
                LabDataModel dataModel = new LabDataModel();
                
                DurumList = dataModel.Durum.ToList();
                var result = DurumList.Where(e => e.DurumId != null && e.IsActive == true).ToList();
                DurumList = result;
                
            }
            catch (Exception ex)
            {

                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }
            return DurumList;
        }

        public int DurumSil(Guid id)
        {
            int sonuc = 0;
            
            using (var context = new LabDataModel())
            {
                Durum durum = context.Durum.FirstOrDefault(x => x.DurumId == id);
                LabTalep veri = context.LabTalep.FirstOrDefault(x => x.DurumId == id || x.GKKSonucId == id || x.SonucDurumId == id);
                if (veri == null)
                {
                    durum.IsActive = false;
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
