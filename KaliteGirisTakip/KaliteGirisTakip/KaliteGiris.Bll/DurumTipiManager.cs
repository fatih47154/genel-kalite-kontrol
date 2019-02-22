using KaliteGiris.EfDal;
using KaliteGiris.IEfDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities;

namespace KaliteGiris.Bll
{
    public class DurumTipiManager : IDurumTipiEf
    {
        IDurumTipiEf DurumTipiEf { get; set; }

        public DurumTipiManager()
        {
            DurumTipiEf = new DurumTipiEf();
        }

        public int DurumTipiEkle(DurumTipi durumTipi)
        {
            int sonuc = 0;
            sonuc = DurumTipiEf.DurumTipiEkle(durumTipi);

            return sonuc;
        }

        public int DurumTipiSil(Guid id)
        {
            int sonuc = 0;
            sonuc = DurumTipiEf.DurumTipiSil(id);

            return sonuc;
        }

        public int DurumTipiGuncelle(DurumTipi durumTipi)
        {
            int sonuc = 0;
            sonuc = DurumTipiEf.DurumTipiGuncelle(durumTipi);

            return sonuc;
        }

        public List<DurumTipi> DurumTipiListele()
        {
            return DurumTipiEf.DurumTipiListele();

        }
    }
}
