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
        SqlCommand command;
        public string kosul { get; set; }
        



        // get the table
        public List<Calisanlar> GetAll(string conditionString="")
        {
            List<Calisanlar> Lcalisan = new List<Calisanlar>();
            try
            {
                querySentence = $"SELECT * FROM tblCalisanlar {conditionString}";
                using (command = new SqlCommand(querySentence, SQLconnection.Connection))
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
            try
            {
                querySentence = "INSERT INTO tblCalisanlar VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
                using (command = new SqlCommand(querySentence, SQLconnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1", calisan.Ad);
                    command.Parameters.AddWithValue("@p2", calisan.Soyad);
                    command.Parameters.AddWithValue("@p3", calisan.TcNo);
                    command.Parameters.AddWithValue("@p4", calisan.PersonelNo);
                    command.Parameters.AddWithValue("@p5", calisan.DogumTarihi);
                    command.Parameters.AddWithValue("@p6", calisan.IseBaslamaTarihi);
                    command.Parameters.AddWithValue("@p7", calisan.Departman);
                    command.Parameters.AddWithValue("@p8", calisan.Unvan);
                    command.Parameters.AddWithValue("@p9", calisan.Durumu);
                    SQLconnection.connectionOPen();
                    command.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {
                
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
                // throw;
            }
            finally
            {
                SQLconnection.connectionClose();
            }
        }
        /// <summary>
        /// ID alarak silme işlemi yapar
        /// </summary>
        /// <param name="calisanlarDAL"></param>
        /// <returns></returns>
        public bool Delete(calisanlarDAL calisanlarDAL )
        {
            try
            {
                querySentence = $"DELETE  FROM tblCalisanlar WHERE ID= @p1 ";
                using (SqlCommand command = new SqlCommand(querySentence, SQLconnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1", calisanlarDAL.kosul);
                    SQLconnection.connectionOPen();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
                // throw;
            }
            finally
            {
                SQLconnection.connectionClose();
            }
           
        }
        public void Update(calisanlarDAL calisanlarDAL)
        {
            
            System.Windows.Forms.MessageBox.Show(typeof(calisanlarDAL).ToString());
            querySentence = $@"UPDATE tblCalisanlar SET @p1";//{calisanlarDAL.kosul} 
            try
            {
                using (SqlCommand command=new SqlCommand(querySentence,SQLconnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1",calisanlarDAL.kosul);
                    SQLconnection.connectionOPen();
                    command.ExecuteNonQuery();
                }
                System.Windows.Forms.MessageBox.Show("Kayıt Başarılı");

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //  throw;
            }
            finally
            {
                SQLconnection.connectionClose();
            }

        }
       








    }
}
