using personel_Takip_28._02._2022.DataAccess;
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
        public FormAna()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCalisanlar.DataSource = calisanDAL.GetAll("WHERE DURUMU='AKTİF'");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            clearTools();

        }
        
        void clearTools()
        {
           // dtpDogumTarihi.CustomFormat = " ";
           // dtpDogumTarihi.Format = DateTimePickerFormat.Custom;
            foreach (Control control in pnlAraclar.Controls)
            {
                if (control.GetType()!=typeof(Label))//sıradaki kontrol label değilse
                {
                    control.Text = string.Empty;
                    if (control.GetType()==typeof(DateTimePicker))
                    {
                        Convert.ToDateTime(control).GetDateTimeFormats()
                    }
                }
                //çalışma sorusu
                //buraya nasıl kod yazılmalıki date time picker nesnesi içi boşaltılsın
            }
        }
    }
}
