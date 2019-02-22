using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities;

namespace KaliteGiris.IEfDal
{
    public interface IAlimTipiEf
    {
        List<AlimTipi> AlimTipiListele();

        int AlimTipiEkle(AlimTipi veri);
    }
}
