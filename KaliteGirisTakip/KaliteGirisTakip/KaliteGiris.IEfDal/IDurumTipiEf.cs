using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.IEfDal
{
    public interface IDurumTipiEf
    {
        int DurumTipiEkle(DurumTipi durumTipi);
        int DurumTipiGuncelle(DurumTipi durumTipi);
        List<DurumTipi> DurumTipiListele();
        int DurumTipiSil(Guid id);


    }
}
