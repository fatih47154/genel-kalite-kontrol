using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.Bll.Abstracts
{
   public  interface IMail
    {
        bool MailGonder(Personel personel);
    }
}
