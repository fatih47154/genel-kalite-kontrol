
using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.IEfDal
{
    public interface ILabTalepEf
    {
        int LabTalepEkle(LabTalep labTalep);
        int LabTalepSil(LabTalep labTalep);
        int LabTalepGuncelle(LabTalep labTalep);
        List<LabTalep> LabTalepListele();

    }
}
