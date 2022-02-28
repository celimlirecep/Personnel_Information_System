using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personel_Takip_28._02._2022.Tools
{
    class SQLbaglanti
    {
        private  static SqlConnection baglanti;
        public static SqlConnection Baglanti
        {
            get //singıltın=> tek bir kere çalıştı- tekbir kere çalışcak döngüye soktuk
            {
                if (baglanti==null)
                {
                    baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["CsPersonel"].ConnectionString);
                }
                return baglanti;
            }
            set
            {
                baglanti = value; 
            }
        }
        public static void baglantiAc()
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                Baglanti.Open();
            }
        }
        public static void baglantiKapat()
        {
            if (baglanti.State == ConnectionState.Open)
            {
                Baglanti.Close();
            }
        }


    }
}
