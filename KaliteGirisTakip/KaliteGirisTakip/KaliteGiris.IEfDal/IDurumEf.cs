using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.IEfDal
{
   public interface IDurumEf
    {
        int DurumEkle(Durum durum);
        int DurumGuncelle(Durum durum);
        List<Durum> DurumListele();
        int DurumSil(Guid id);
    }
}
