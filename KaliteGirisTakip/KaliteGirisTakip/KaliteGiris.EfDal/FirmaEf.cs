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
    public class FirmaEf : IFirmaEf
    {
        Firma firma { get; set; }


        public int FirmaEkle(Firma firma)
        {
            int sonuc = 0;
            string date = DateTime.Now.ToString();
            firma.CreatedDate = Convert.ToDateTime(date);
            try
            {              
                LabDataModel dataModel = new LabDataModel();
                dataModel.Firma.Add(firma);
                sonuc = dataModel.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return sonuc;
        }
        public int FirmaGuncelle(Firma firma)
        {  
            int sonuc = 0;
            string date = DateTime.Now.ToString();
            firma.UpdatededDate = Convert.ToDateTime(date);

            using (var context = new LabDataModel())
            {
                context.Entry(firma).State = EntityState.Modified;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;           
        }
        public List<Firma> FirmaListele()
        {
            List<Firma> FirmaList = null;
            try
            {
                LabDataModel dataModel = new LabDataModel();                
                FirmaList = dataModel.Firma.ToList();
                var result = FirmaList.Where(e => e.FirmaId != null).ToList();
                FirmaList = result;
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }
            return FirmaList;
        }
        public int FirmaSil(Guid id)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                Firma firma = context.Firma.FirstOrDefault(x => x.FirmaId == id);
                LabTalep veri = context.LabTalep.FirstOrDefault(x => x.FirmaId == id );
                if (veri == null)
                {
                    context.Firma.Remove(firma);
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
