using System;
using Personel_Information_v2.DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Personel_Information_v2.Entities;

namespace Personel_Information_v2
{
    public partial class Form1 : Form
    {
        calisanlarDAL calisanDal = new calisanlarDAL();
        string kosul = string.Empty;
        string SelectedID = string.Empty;
        



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
           
        }
        void refresh()
        {
            dgvCalisanlar.DataSource = calisanDal.GetAll();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (IsFull())
            {
                    Calisanlar calisanlar = new Calisanlar
                    {
                        Ad = txtaAd.Text,
                        Soyad = txtSoyad.Text,
                        TcNo = txtTcNo.Text,
                        PersonelNo = txtPersonelNo.Text,
                        DogumTarihi = dtpDogumTarihi.Value,
                        IseBaslamaTarihi = dtpİseBaslamaTarihi.Value,
                        Departman = cmbDepartman.SelectedItem.ToString(),
                        Unvan = cmbUnvan.SelectedItem.ToString(),
                        Durumu = cmbDurumu.SelectedItem.ToString()
                    };
                    calisanDal.Insert(calisanlar);
                refresh();
            }
        }
        /// <summary>
        /// Butun kutucuklar dolu ise true döndürür
        /// </summary>
        /// <returns></returns>
        private bool IsFull()
        {
            bool fullmi = true;
            foreach (Control control in pnlAraclar.Controls)
            {
                if (control.Text==string.Empty|| control.Text==" ")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz");
                    fullmi = false;
                    break;
                }
            }
            return fullmi;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            calisanDal.kosul = SelectedID;
            calisanDal.Delete(calisanDal);
            refresh();
        }

        void Transfer()
        {
            SelectedID = dgvCalisanlar.SelectedRows[0].Cells[0].Value.ToString();
            txtaAd.Text = dgvCalisanlar.SelectedRows[0].Cells[1].Value.ToString();
            txtSoyad.Text = dgvCalisanlar.SelectedRows[0].Cells[2].Value.ToString();
            txtTcNo.Text = dgvCalisanlar.SelectedRows[0].Cells[3].Value.ToString();
            txtPersonelNo.Text = dgvCalisanlar.SelectedRows[0].Cells[4].Value.ToString();
            dtpDogumTarihi.Value = Convert.ToDateTime(dgvCalisanlar.SelectedRows[0].Cells[5].Value);
            dtpİseBaslamaTarihi.Value = Convert.ToDateTime(dgvCalisanlar.SelectedRows[0].Cells[6].Value);
            cmbDepartman.SelectedItem= dgvCalisanlar.SelectedRows[0].Cells[7].Value.ToString();
            cmbUnvan.SelectedItem= dgvCalisanlar.SelectedRows[0].Cells[8].Value.ToString();
            cmbDurumu.SelectedItem = dgvCalisanlar.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
            List<string> kosullar = new List<string>();
            if (IsFull())
            {
                foreach (Control control in pnlAraclar.Controls)
                {
                    if (control.GetType()==typeof(DateTimePicker))
                    {
                        kosullar.Add(control.Tag.ToString() + " = '" + Convert.ToDateTime(control.Text).ToString("yyyy-MM-dd") + "'");
                    }
                    else
                    {
                        kosullar.Add(control.Tag.ToString() + " = '" + control.Text + "'");
                    }
                  
                }
                kosul = string.Join(" , ", kosullar);
            }
            kosul =kosul+" WHERE ID = '"+SelectedID+"'";
            calisanlarDAL kosulGuncelle = new calisanlarDAL();
            kosulGuncelle.kosul = kosul;
            MessageBox.Show(kosulGuncelle.kosul.ToString());
           calisanDal.Update(kosulGuncelle);
            refresh();


        }

        private void dgvCalisanlar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Transfer();
            }
            catch (Exception)
            {

               // throw;
            }
        }
    }
}
