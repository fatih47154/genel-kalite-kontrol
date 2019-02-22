using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities;
using KaliteGiris.IEfDal;
using KaliteGiris.EfDal;

namespace KaliteGiris.Bll
{
    public class AlimTipiManager : IAlimTipiEf
    {
        IAlimTipiEf AlimTipiEf { get; set; }

        public AlimTipiManager()
        {
            AlimTipiEf = new AlimTipiEf();
        }
        public List<AlimTipi> AlimTipiListele()
        {
            return AlimTipiEf.AlimTipiListele();
        }

        public int AlimTipiEkle(AlimTipi veri)
        {
            int sonuc = 0;
            sonuc = AlimTipiEf.AlimTipiEkle(veri);

            return sonuc;
        }
    }
}
