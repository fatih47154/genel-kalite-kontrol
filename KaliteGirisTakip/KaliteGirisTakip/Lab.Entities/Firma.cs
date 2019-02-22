using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGirisProje
{
    [Table("Firma")]
    public partial class Firma
    {
        public Guid FirmaId { get; set; }
        public string FirmaAdi { get; set; }
        public bool Durum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kayit> Kayit { get; set; }
    }
}
