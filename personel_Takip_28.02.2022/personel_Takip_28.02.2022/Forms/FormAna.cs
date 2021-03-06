using personel_Takip_28._02._2022.DataAccess;
using personel_Takip_28._02._2022.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personel_Takip_28._02._2022
{
    public partial class FormAna : Form
    {

        CalisanDAL calisanDAL = new CalisanDAL();
        int secilenID=0;
        calisan calisan = null;
        String orjinalPersonelNO;

        public FormAna()
        {
            InitializeComponent();
        }
        void Refresh()
        {
            dgvCalisanlar.DataSource = calisanDAL.GetAll();//where ıd....
        }
     

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
            Transfer();
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            clearTools();


        }
        
        void clearTools()
        {
          
            foreach (Control control in pnlAraclar.Controls)//***********************************************
            {
                if (control.GetType()!=typeof(Label))//sıradaki kontrol label değilse
                {
                    control.Text = string.Empty;
                    
                }
                
                //çalışma sorusu
                //buraya nasıl kod yazılmalıki date time picker nesnesi içi boşaltılsın
            }
            dtpDogumTarihi.Format = DateTimePickerFormat.Custom;
            dtpDogumTarihi.CustomFormat = " ";
            dtpİseBaslamaTarihi.Format = DateTimePickerFormat.Custom;
            dtpİseBaslamaTarihi.CustomFormat = " ";
          
            txtaAd.Focus();
            Cancel();
            Refresh();
          
        }

        private void dtpDogumTarihi_ValueChanged(object sender, EventArgs e)
        {
            dtpDogumTarihi.Format = DateTimePickerFormat.Long;
          
        }

        private void dtpİseBaslamaTarihi_ValueChanged(object sender, EventArgs e)
        {
            dtpİseBaslamaTarihi.Format = DateTimePickerFormat.Long;
        }

        private void dgvCalisanlar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
               Transfer();
        }
        void Transfer()
        {
            calisan= new calisan();
           try
            {
                
                secilenID = Convert.ToInt32(dgvCalisanlar.SelectedRows[0].Cells[0].Value);
                txtaAd.Text = dgvCalisanlar.SelectedRows[0].Cells[1].Value.ToString().ToUpper();
                txtSoyad.Text = dgvCalisanlar.SelectedRows[0].Cells[2].Value.ToString();
                txtTcNo.Text = dgvCalisanlar.SelectedRows[0].Cells[3].Value.ToString();
                dtpİseBaslamaTarihi.Format = DateTimePickerFormat.Long;
                orjinalPersonelNO = txtPersonelNo.Text = dgvCalisanlar.SelectedRows[0].Cells[4].Value.ToString();
                dtpDogumTarihi.Value = Convert.ToDateTime(dgvCalisanlar.SelectedRows[0].Cells[5].Value.ToString());
                dtpİseBaslamaTarihi.Format = DateTimePickerFormat.Long;
                dtpİseBaslamaTarihi.Value = Convert.ToDateTime(dgvCalisanlar.SelectedRows[0].Cells[6].Value.ToString());
                cmbDepartman.Text = dgvCalisanlar.SelectedRows[0].Cells[7].Value.ToString();
                cmbUnvan.Text = dgvCalisanlar.SelectedRows[0].Cells[8].Value.ToString();
                cmbDurumu.Text = dgvCalisanlar.SelectedRows[0].Cells[9].Value.ToString();
           }
            catch (Exception ex)
            {
              ///  MessageBox.Show(ex.Message);
                // throw;
            }
          
        }
     
        bool BlankControl()
        {
            bool result = true;
            foreach (Control control in pnlAraclar.Controls)
            {
                if (control.Text==string.Empty|| control.Text==" ")
                {
                    result = false;
                    break;
                }

            }
            return result;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!BlankControl())
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");
            }
            else
            {
                calisan.ID = secilenID;
                calisan.Ad = txtaAd.Text;
                calisan.Soyad = txtSoyad.Text;
                calisan.TcNo = txtTcNo.Text;
                calisan.PersonelNo = txtPersonelNo.Text;
                calisan.DogumTarihi = dtpDogumTarihi.Value;
                calisan.IseBaslamaTarihi = dtpİseBaslamaTarihi.Value;
             //   calisan.Departman = Convert.ToInt32( cmbDepartman.SelectedValue);
             //   calisan.Unvan = Convert.ToInt32(cmbUnvan.SelectedValue);
                calisan.Durumu = cmbDurumu.SelectedItem.ToString();
                
                
            }
            bool result = calisanDAL.Insert(calisan);
            if (result)
            {
                Refresh();
                MessageBox.Show("KAYİT BASARILI");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenID==0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçiniz!!!");
            }
            else
            {
                DialogResult answer = MessageBox.Show("Seçilen kayıt silinicektir!!!\nEminmisiniz?","DİKKAT",MessageBoxButtons.YesNo);
                if (answer==DialogResult.Yes)
                {
                    bool result=calisanDAL.Delete(secilenID);
                    if (result )
                    {
                        Refresh();
                        MessageBox.Show($"{secilenID} li degerin Silme işlemi gerçekleşmiştir");
                    }
                  
                }
            }
           
            
        }
        void Cancel()
        {
            dgvCalisanlar.ClearSelection();
            secilenID = 0;
        }

        private void btnHepsiniSil_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Tablonuzdaki tüm kayıtlar silinicektir!!!\n Eminmisiniz","Dikkat tüm kayıtlar silinicek",MessageBoxButtons.YesNo);
            if (answer==DialogResult.Yes)
            {
                bool result = calisanDAL.Delete();
                if (result)
                {
                    MessageBox.Show("Tüm kayıtlar silinicektir");
                    Refresh();
                   
                }
                clearTools();
                //sadece seçili kayıtları silecek kayıtları seçmeye çalışın

            }
        }

        private void dgvCalisanlar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Escape)//basılan tuş escape ise
            {
                clearTools();
            }
        }

        string CreateQueryString()
        {
            string queryString = string.Empty;
            List<string> alanlar = new List<string>();
            foreach (Control control in pnlAraclar.Controls)
            {
                if (control.Tag==null) continue;//döngüyü başa sar diğer  item bilgisine bak
                string fieldName = control.Tag.ToString();
                string value = string.Empty;
                if (string.IsNullOrEmpty(control.Text) || control.Text == " ") continue;//date time pickerlarda içinde bi boş karakter var
                if (control.GetType() == typeof(DateTimePicker))
                {
                    value =Convert.ToDateTime( control.Text).ToString("yyyy-MM-dd");
                    alanlar.Add($" {fieldName} ='{value}'");

                }
                else
                {
                    value = control.Text;
                    
                    if (rdbBenzer.Checked)
                    {
                        alanlar.Add($" {fieldName} LIKE '%{value}%'");
                    }
                    else if (rdbIleBaslayan.Checked)
                    {
                        alanlar.Add($" {fieldName} LIKE '{value}%'");
                    }
                    else
                    {
                        alanlar.Add($" {fieldName} ='{value}'");
                    }

                }
              
               
            }

            if (alanlar.Count<=0)
            {
               // MessageBox.Show("aramak istediğiniz degerleri yazınız");
            }
            else
            {
                queryString = $" WHERE {string.Join(" AND ",alanlar)}";
            }
            Refresh();
            return queryString;
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            dgvCalisanlar.DataSource = calisanDAL.GetAll(CreateQueryString());
       
        }
     

        private void btnGetir_Click(object sender, EventArgs e)
        {
            calisan calisan = new calisan();
            calisan = calisanDAL.Get(CreateQueryString());
            if (calisan!=null)
            {
                txtaAd.Text = calisan.Ad;
                txtSoyad.Text = calisan.Soyad;
                txtTcNo.Text = calisan.TcNo;
                txtPersonelNo.Text = calisan.PersonelNo;
                dtpDogumTarihi.Format = DateTimePickerFormat.Long;
                dtpDogumTarihi.Value = calisan.DogumTarihi;
                dtpİseBaslamaTarihi.Format = DateTimePickerFormat.Long;
                dtpİseBaslamaTarihi.Value = calisan.IseBaslamaTarihi;
              //  cmbDepartman.Text = calisan.Departman.ToString();
               // cmbUnvan.Text = calisan.Unvan.ToString();
                cmbDurumu.Text = calisan.Durumu;

            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenID==0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kaydı seçiniz!!!");
            }
            else if(!BlankControl())
            {
                MessageBox.Show("Tüm alanları Doldurunuz!!!");
            }
            else
            {
                calisan calisan;
                calisan = new calisan
                {
                    ID = secilenID,
                    Ad = txtaAd.Text,
                    Soyad = txtSoyad.Text,
                    TcNo = txtTcNo.Text,
                    PersonelNo = txtPersonelNo.Text,
                    DogumTarihi = dtpDogumTarihi.Value,
                    IseBaslamaTarihi = dtpİseBaslamaTarihi.Value,
                  //  Departman =cmbDepartman.SelectedValue,
                   // Unvan =Convert.ToInt32( cmbUnvan.SelectedValue),
                    Durumu = cmbDurumu.SelectedItem.ToString()
                };

                bool girdi = true;
                  if (calisanDAL.Dublicate($"WHERE PersonelNo='{calisan.PersonelNo}'") == 1 )//daha önce kayıt oluşturulmuş
                  {
                        if (orjinalPersonelNO!=calisan.PersonelNo)
                        {
                            System.Windows.Forms.MessageBox.Show("Bu telefon numarası daha önce oluşturulmuş");
                            calisan.PersonelNo = orjinalPersonelNO;
                            girdi = false;
                        }
                  }

                if (calisanDAL.Update(calisan) && girdi  )
                {
                    MessageBox.Show("Güncelleme başarılı");
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız");
                }
            }
            Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(calisanDAL.Dublicate(@"WHERE PersonelNo= '"+txtPersonelNo.Text+"'").ToString());
        }
    }
}
