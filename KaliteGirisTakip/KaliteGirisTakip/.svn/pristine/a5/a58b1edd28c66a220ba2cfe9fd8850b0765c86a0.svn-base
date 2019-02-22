using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.IEfDal;
using KaliteGiris.EfDal;
using KaliteGiris.Entities;

namespace KaliteGiris.Bll
{
    public class LabTalepManager : ILabTalepEf
    {
        ILabTalepEf LabTalepEf { get; set; }

        public LabTalepManager()
        {
            LabTalepEf = new LabTalepEf();
        }
        public List<LabTalep> LabTalepListele()
        {
            return LabTalepEf.LabTalepListele();
        }

        public int LabTalepEkle(LabTalep labTalep)
        {
            int sonuc = 0;
            sonuc = LabTalepEf.LabTalepEkle(labTalep);

            return sonuc;
        }

        public int LabTalepGuncelle(LabTalep labTalep)
        {
            int sonuc = LabTalepEf.LabTalepGuncelle(labTalep);
            return sonuc;
        }

        public int LabTalepSil(LabTalep labTalep)
        {
            int sonuc = 0;
            sonuc = LabTalepEf.LabTalepSil(labTalep);

            return sonuc;
        }
    }
}

       