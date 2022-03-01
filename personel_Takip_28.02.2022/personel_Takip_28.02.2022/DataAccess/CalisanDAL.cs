using personel_Takip_28._02._2022.Entities;
using personel_Takip_28._02._2022.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personel_Takip_28._02._2022.DataAccess
{
    class CalisanDAL
    {
        //Burada ise Data access laye hazaırlıyoruz
        //Yani çalışan entitilerimizle ilgili CRUD vb işlemlerimiz burada

        /// <summary>
        /// Bu method geriye içinde çalışan tipinde degereler barındıran bir list döndürecek
        /// </summary>
        /// <param name="kosulCUmlesi">
        /// bu parametre boş bırakılırsa yani "" veya string.empty şeklinde kullanılırsa tüm 
        /// kayıtları döndürücek. Buraya uygun bir WHERE ifadesi yazılırsa koşula uygun kayıtları döndürecek
        /// </param>
        /// <returns></returns>
        public List<calisan> GetAll(string kosulCumlesi="")//"" anlamı boş bırakılabilir isteğe bağlı
        {
            List<calisan> calisanlar = new List<calisan>();
            try
            {
                //Buraya yazacağımız işlemleri dene sorun yoksa çalıştır
                                                  //koşul cümles ile WHERE .... ile sorgu yazıp istediğimiz degerleri döndürebilmek
                using (SqlCommand command = new SqlCommand($"SELECT * FROM tblCalisanlar {kosulCumlesi}", SQLbaglanti.Baglanti))
                {
                    //using satırında yaratılşan nesne sadece bu scopta yaşayacak bu scop dışında yok olacak
                    //garbage collector insiyatifine bırakmamış olduk. 
                    // kullan sil
                    SQLbaglanti.baglantiAc();
                    using (SqlDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())//geri dönen degerlerin hepsine bakmamızı saglar, okuma false verene kadar
                        {
                        calisan calisan = new calisan
                        {
                                ID = Convert.ToInt32(reader["ID"]),
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                TcNo = reader["TcNo"].ToString(),
                                PersonelNo = reader["PersonelNo"].ToString(),
                                DogumTarihi=Convert.ToDateTime(reader["DogumTarihi"]),
                                IseBaslamaTarihi= Convert.ToDateTime(reader["IseBaslamaTarihi"]),
                                Departman= reader["Departman"].ToString(),
                                Unvan= reader["Unvan"].ToString(),
                                Durumu= reader["Durumu"].ToString()

                            };
                            calisanlar.Add(calisan);
                        }
                    }
                }
                return calisanlar;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
              //  throw; // HATA VARSA PROGRAMDA DURUCAK
            }
            finally
            {
                SQLbaglanti.baglantiKapat();// try ve catch için ikisindede kullanmak için kullanırız
            }
        }
        public bool Insert(calisan ccalisan)
        {
            string sorguCumlesi = $"INSERT INTO tblCalisanlar " +
                $"(Ad,Soyad,TcNo,PersonelNo,DogumTarihi,IseBaslamaTarihi,Departman,Unvan,Durumu)" +
                $"VALUES" +
                $"(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            try// hatalara karşı önlem olsun diye server vs çalışmaz
            {
                using (SqlCommand command=new SqlCommand(sorguCumlesi,SQLbaglanti.Baglanti))
                {
                    command.Parameters.AddWithValue("@p1", ccalisan.Ad);
                    command.Parameters.AddWithValue("@p2", ccalisan.Soyad);
                    command.Parameters.AddWithValue("@p3", ccalisan.TcNo);
                    command.Parameters.AddWithValue("@p4", ccalisan.PersonelNo);
                    command.Parameters.AddWithValue("@p5", ccalisan.DogumTarihi);
                    command.Parameters.AddWithValue("@p6", ccalisan.IseBaslamaTarihi);
                    command.Parameters.AddWithValue("@p7", ccalisan.Departman);
                    command.Parameters.AddWithValue("@p8", ccalisan.Unvan);
                    command.Parameters.AddWithValue("@p9", ccalisan.Durumu);
                    SQLbaglanti.baglantiAc();
                    command.ExecuteNonQuery();
                }
                return true;// Kayit başarılı

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;// akyıt başarısız
              //  throw;
            }
            finally
            {
                SQLbaglanti.baglantiKapat();
            }
        }
        public bool Update(calisan ccalisan)
        {
            string sorgucumlesi = $"UPDATE tblCalisanlar SET" +
                $"Ad=@p1,Soyad=@p2,TcNo=@p3," +
                $"PersonelNo=@p4,DogumTarihi=@p5," +
                $"IseBaslamaTarihi=@p6,Departman=@p7," +
                $"Unvan=@p8,Durumu=@p9 WHERE ID=@P10";
            try
            {
                using (SqlCommand command=new SqlCommand(sorgucumlesi,SQLbaglanti.Baglanti))
                {
                    command.Parameters.AddWithValue("@p1", ccalisan.Ad);
                    command.Parameters.AddWithValue("@p2", ccalisan.Soyad);
                    command.Parameters.AddWithValue("@p3", ccalisan.TcNo);
                    command.Parameters.AddWithValue("@p4", ccalisan.PersonelNo);
                    command.Parameters.AddWithValue("@p5", ccalisan.DogumTarihi);
                    command.Parameters.AddWithValue("@p6", ccalisan.IseBaslamaTarihi);
                    command.Parameters.AddWithValue("@p7", ccalisan.Departman);
                    command.Parameters.AddWithValue("@p8", ccalisan.Unvan);
                    command.Parameters.AddWithValue("@p9", ccalisan.Durumu);
                    command.Parameters.AddWithValue("@p10",ccalisan.ID);
                    SQLbaglanti.baglantiAc();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
              //  throw;
            }
            finally
            {
                SQLbaglanti.baglantiKapat();
            }
        }
        public bool Delete(int id)
        {
            string sorguCumlesi = "DELETE FROM tblCalisanlar WHERE ID =@p1";
            try
            {
                using (SqlCommand command=new SqlCommand(sorguCumlesi,SQLbaglanti.Baglanti))
                {
                    command.Parameters.AddWithValue("@p1", id);
                    SQLbaglanti.baglantiAc();
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
                SQLbaglanti.baglantiKapat();
            }
        }
        public bool Delete(string kosulCumlesi="")
        {
            string sorguCumlesi = $"DELETE FROM tblCalisanlar {kosulCumlesi}";
            try
            {
                using (SqlCommand command=new SqlCommand(sorguCumlesi,SQLbaglanti.Baglanti))
                {
                   // command.Parameters.AddWithValue("@p1", kosulCumlesi);
                    SQLbaglanti.baglantiAc();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
                //  throw;
            }
            finally
            {
                SQLbaglanti.baglantiKapat();
            }
        }



    }
}
