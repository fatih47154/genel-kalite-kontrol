﻿using KaliteGiris.Entities;
using KaliteGiris.IEfDal;
using KaliteGiris.EfDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.Bll
{
    public class FirmaManager : IFirmaEf
    {
        IFirmaEf FirmaEf { get; set; }

        public FirmaManager()
        {
            FirmaEf = new FirmaEf();
        }
        public List<Firma> FirmaListele()
        {
            return FirmaEf.FirmaListele();
        }
        public int FirmaEkle(Firma Firma)
        {
            int sonuc = 0;
            sonuc = FirmaEf.FirmaEkle(Firma);

            return sonuc;

        }
        public int FirmaGuncelle(Firma firma)
        {
            int sonuc = 0;
            sonuc = FirmaEf.FirmaGuncelle(firma);

            return sonuc;
        }
        public int FirmaSil(Guid id)
        {
            int sonuc = 0;
            sonuc = FirmaEf.FirmaSil(id);

            return sonuc;
        }
        public static object CreateInstance()
        {
            throw new NotImplementedException();
        }
    }
}
