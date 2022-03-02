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

namespace Personel_Information_v2
{
    public partial class Form1 : Form
    {
        calisanlarDAL calisanlar = new calisanlarDAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           dgvCalisanlar.DataSource= calisanlar.GetAll();
        }
    }
}
