using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities.Abstract;

namespace KaliteGiris.Entities
{
    [Table("Firma")]
    public partial class Firma : ABaseEntity
    {
        public Firma()
        {
            LabTaleps = new List<LabTalep>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid FirmaId { get; set; }

        [StringLength(100)]
        public string FirmaAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LabTalep> LabTaleps { get; set; }


    }
}
