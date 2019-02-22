using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.IEfDal
{
   public interface IFirmaEf
    {
        int FirmaEkle(Firma firma);
        int FirmaGuncelle(Firma firma);
        int FirmaSil(Guid id);
        List<Firma> FirmaListele();
    }
}
