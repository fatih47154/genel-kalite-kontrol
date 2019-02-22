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
    public class KayitDuzenle
    {
        KaliteGiris.EfDal.KayitDuzenleEf db = new KayitDuzenleEf();
        public int kayitDuzenle(LabTalep veri)
        {
            int sonuc = 0;
            sonuc = db.kayitDuzenleEf(veri);
            return sonuc;
        }
    }
}
