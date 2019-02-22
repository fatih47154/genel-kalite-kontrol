
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
    public partial class LabTalepEf : ILabTalepEf
    {
       LabTalep LabTalep { get; set; }


        public int LabTalepEkle(LabTalep labTalep)
        {
            string date = DateTime.Now.ToString();
            LabTalep.CreatedDate = Convert.ToDateTime(date);
            LabDataModel dataModel = new LabDataModel();

            dataModel.LabTalep.Add(labTalep);
            int sonuc = dataModel.SaveChanges();

            return sonuc;
        }

        public int LabTalepGuncelle(LabTalep labTalep)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                context.Entry(labTalep).State = EntityState.Modified;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;
        }

        public List<LabTalep> LabTalepListele()
        {
            List<LabTalep> LabTalepList = new List<LabTalep>();
            
          
                LabDataModel dataModel = new LabDataModel();
                
                LabTalepList = dataModel.LabTalep.Where(x => x.IsActive == true).ToList();
                var result = LabTalepList.ToList();
                LabTalepList = result;
           
            return LabTalepList;
        }
        
        public int LabTalepSil(LabTalep labTalep)
        {
            int sonuc = 0;

            using (var context = new LabDataModel())
            {
                context.Entry(labTalep).State = EntityState.Deleted;
                context.SaveChanges();
                sonuc = 1;
            }

            return sonuc;
        }
    }
}
