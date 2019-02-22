using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.EfDal;
using KaliteGiris.Entities;

namespace KaliteGiris.Bll
{
    public class LoginManager
    {
        LoginEf LoginEf { get; set; }
        public LoginManager()
        {
            LoginEf = new LoginEf();
        }

        public Personel Login(string kullaniciAdi,string sifre)
        {
            Personel sonuc;
            sonuc = LoginEf.login(kullaniciAdi, sifre);
            return sonuc;
        }
    }
}
