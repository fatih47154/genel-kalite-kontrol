using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities;

namespace KaliteGiris.EfDal
{
    public class LoginEf
    {
        public Personel login(string kullaniciAdi,string sifre)
        {
            Personel sonuc;
           
                LabDataModel db = new LabDataModel();
                Personel k = db.Personel.Where(x => x.Kullanici == kullaniciAdi && x.Sifre == sifre).SingleOrDefault();
                sonuc = k;
            
            return sonuc;
        }

    }
}
