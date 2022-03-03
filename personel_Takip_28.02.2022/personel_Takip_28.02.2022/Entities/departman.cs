using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personel_Takip_28._02._2022.Entities
{
    public class departman:IBaseEntıty
    {
        public string Sorumlu { get; set; }
        public int ID { get ; set ; }
        public string Ad { get ; set ; }
    }
}
