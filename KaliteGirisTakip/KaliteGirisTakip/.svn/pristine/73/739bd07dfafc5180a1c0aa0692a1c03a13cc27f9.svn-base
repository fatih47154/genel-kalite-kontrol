namespace Lab.Entities
{
    using KaliteGirisProje;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;


    [Table("LabTalep")]
    public partial class LabTalep
    {
       /*public LabTalep()
        {

          Kayit = new HashSet<LabTalep>();
            // Ucretler = new HashSet<Ucret>();

        }*/
        public Guid LabTalepId { get; set; }
        public int Sira { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime RaporTarihi { get; set; }
        public Guid FirmaID { get; set; }
        public string SozlesmeNo { get; set; }
        public string AlimTipi { get; set; }
        public string Malzeme { get; set; }
        public string IrsaliyeNo { get; set; }
        public Guid GkkPersonelId { get; set; }
        public string LabDurum { get; set; }
        public string LabSonucu { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<Kayit> Kayit { get; set; }

        //public static implicit operator LabTalep(List<LabTalep> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
