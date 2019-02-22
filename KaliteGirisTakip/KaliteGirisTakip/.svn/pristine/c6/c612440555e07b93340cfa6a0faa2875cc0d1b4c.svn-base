using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGirisProje
{
    [Table("Personel")]
    public partial class Personel
    {
            public Guid PersonelId { get; set; }
            public int SicilNo { get; set; }
            public string Adi { get; set; }
            public string Soyadi { get; set; }
            [StringLength(11)]
            public string Tc { get; set; }
            public string Kullanici { get; set; }
            public string Sifre { get; set; }
            public string EMail { get; set; }
            public bool Durum { get; set; }


            public virtual ICollection<Kayit> Kayit { get; set; }
        
    }
}
