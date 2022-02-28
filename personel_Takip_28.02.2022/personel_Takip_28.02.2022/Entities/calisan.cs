 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personel_Takip_28._02._2022.Entities
{
    class calisan
    {// Bu class bizim entities katmanındadır
        //Entititlerimizden tblCalisanlara ait bir entitie için hazırlandı
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public string PersonelNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime IseBaslamaTarihi { get; set; }
        public string Departman { get; set; }
        public string Unvan { get; set; }
        public String Durumu { get; set; }


    }
}
