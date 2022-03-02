using Personel_Information_v2.Entities;
using Personel_Information_v2.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel_Information_v2.DataAccess
{
    

    class calisanlarDAL
    {
        string querySentence = "";

        // get the table
        public List<Calisanlar> GetAll(string conditionString="")
        {
            List<Calisanlar> Lcalisan = new List<Calisanlar>();
            try
            {
                querySentence = $"SELECT * FROM tblCalisanlar {conditionString}";
                using (SqlCommand command = new SqlCommand(querySentence, SQLconnection.Connection))
                {
                    SQLconnection.connectionOPen();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Calisanlar calisan = new Calisanlar
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Ad = reader["AD"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                TcNo = reader["TcNo"].ToString(),
                                PersonelNo = reader["PersonelNo"].ToString(),
                                DogumTarihi = Convert.ToDateTime(reader["DogumTarihi"]),
                                IseBaslamaTarihi = Convert.ToDateTime(reader["IseBaslamaTarihi"]),
                                Departman = reader["Departman"].ToString(),
                                Unvan = reader["Unvan"].ToString(),
                                Durumu = reader["Durumu"].ToString(),
                            };
                            Lcalisan.Add(calisan);

                        }

                    }

                }
                return Lcalisan;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
              
                //throw;
            }
            finally
            {
                SQLconnection.connectionClose();
            }



        }
        public bool Insert(Calisanlar calisan)
        {
            querySentence="INSERT INTO tblCalisanlar "



        }








    }
}
