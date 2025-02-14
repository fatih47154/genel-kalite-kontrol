﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaliteGiris.Entities.Abstract;

namespace KaliteGiris.Entities
{
    [Table("Durum")]
    public partial class Durum : ABaseEntity
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public Guid DurumId { get; set; }

            [StringLength(100)]
            public string DurumAdi { get; set; }
           
            public Guid DurumTipiId { get; set; }
            
            public virtual DurumTipi DurumTipi { get; set; }
 
        
        }
}
