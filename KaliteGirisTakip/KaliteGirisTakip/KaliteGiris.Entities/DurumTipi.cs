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
    [Table("DurumTipis")]
   public partial class DurumTipi : ABaseEntity
    {
        public DurumTipi()
            {
                Durums = new List<Durum>();
            }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public Guid DurumTipiId { get; set; }

            [StringLength(100)]
            public string DurumTip { get; set; }
        
            public virtual ICollection<Durum> Durums { get; set; }

    }
    }
