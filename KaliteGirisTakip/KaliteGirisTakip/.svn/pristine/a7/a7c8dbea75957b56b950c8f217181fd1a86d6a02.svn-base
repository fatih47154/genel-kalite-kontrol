using Lab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaliteGirisProje
{
    public partial class Kayit
    {

        public int KayitId { get; set; }
        public Guid FirmaId { get; set; }
        public Guid PersonelId { get; set; }


        public virtual Firma Firma { get; set; }
        public virtual Personel Personel { get; set; }

        public virtual LabTalep LabTalep { get; set; }
    }
}
