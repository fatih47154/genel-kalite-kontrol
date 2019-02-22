using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KaliteGiris.Entities
{

    [DataContract]
    public class PersonelBilgi
    {
        [DataMember]
        public int PersonelId { get; set; }
        [DataMember]
        public int SicilNo { get; set; }
        [DataMember]
        public string Adi { get; set; }
        [DataMember]
        public string Soyadi { get; set; }
        [DataMember]
        public string Sube { get; set; }
        [DataMember]
        public string DepartmanAdi { get; set; }
        [DataMember]
        public string Unvan { get; set; }
        [DataMember]
        public int SubeId { get; set; }

        [DataMember]
        public int UnvanId { get; set; }

        [DataMember]
        public int DepartmanId { get; set; }

        public int PersonelTurId { get; set; }
    }
}
