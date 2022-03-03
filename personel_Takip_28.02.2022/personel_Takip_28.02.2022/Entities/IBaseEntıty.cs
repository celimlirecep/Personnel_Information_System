using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personel_Takip_28._02._2022.Entities
{
    interface IBaseEntıty
    {
        //erişim belirleyici yok
        //fonksiyonların içi doldurulmaz
        // ismi I ile başlar
        //abstract=soyut(ınterface veri yok sadece adlandırma var) concreate=somut
         int ID { get; set; }
         string Ad { get; set; }


    }
}
