using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.EfDal;
using KaliteGiris.Entities;
using KaliteGiris.IEfDal;

namespace KaliteGiris.EfDal
{
    public class AlimTipiEf : IAlimTipiEf
    {
        AlimTipi AlimTipi { get; set; }

        public List<AlimTipi> AlimTipiListele()
        {
            List<AlimTipi> AlimTipiList = null;
            try
            {
                LabDataModel dataModel = new LabDataModel();
                AlimTipiList = dataModel.AlimTipi.ToList();
                var result = AlimTipiList.Where(e => e.AlimTipiId != null && e.IsActive == true).ToList();
                AlimTipiList = result;
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }
            return AlimTipiList;
        }

        public int AlimTipiEkle(AlimTipi veri)
        {
            int sonuc = 0;
            veri.IsActive = true;
            string date = DateTime.Now.ToString();
            veri.CreatedDate = Convert.ToDateTime(date);

            try
            {
                LabDataModel dataModel = new LabDataModel();
                dataModel.AlimTipi.Add(veri);
                sonuc = dataModel.SaveChanges();
            }
            catch (Exception ex)
            {
 
            }
            return sonuc;
        }
    }
}
