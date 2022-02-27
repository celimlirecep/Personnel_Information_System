using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personnel_Information_System
{
    public partial class Form1 : Form
    {
        Database db = new Database();
        Employee employee = new Employee();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshDegree();
            refreshDepartment();
            refreshPerson();
            refreshEmployee();
        }
        void refreshDegree()
        {
            db.TableName = "tblDegree";
            db.operation();
            dgvDegree.DataSource = db.Dt;
            dgvEmployeeDegree.DataSource = db.Dt;
            dgvEmployeeDegree.Columns[0].Visible = false;
        }
        void refreshEmployee()
        {
            db.TableName = "tblEmployee";
            db.operation();
            dgvEmployee.DataSource = db.Dt;
        }
        void refreshPerson()
        {
            db.TableName = "tblPerson";
            db.operation();
            dgvEmployeePerson.DataSource = db.Dt;
            dgvPerson.DataSource = db.Dt;
            for (int i = 0; i <dgvEmployeePerson.Columns.Count; i++)
            {
                dgvEmployeePerson.Columns[i].Visible = false;
            }
            dgvEmployeePerson.Columns[1].Visible = true;
            dgvEmployeePerson.Columns[2].Visible = true;

        }
        void refreshDepartment()
        {
            db.TableName = "tblDepartment";
            db.operation();
            dgvDepartment.DataSource = db.Dt;
            dgvEmployeeDepatment.DataSource = db.Dt;
            dgvEmployeeDepatment.Columns[0].Visible = false;
        }

       

        private void btnEmployeeADD_Click(object sender, EventArgs e)
        {
           
            employee.EmployeeNumber = txtEmployeeCode.Text;
            employee.EmployeeNameID = Convert.ToInt32(dgvEmployeePerson.SelectedRows[0].Cells[0].Value.ToString());
            employee.DateOfStart = dtpDateOfStart.Value;
            employee.DepartmantID = Convert.ToInt32(dgvEmployeeDepatment.SelectedRows[0].Cells[0].Value.ToString());
            employee.DegreeID = Convert.ToInt32(dgvEmployeeDegree.SelectedRows[0].Cells[0].Value.ToString());
            employee.WorkingStatus = checkBox1.Checked;
            db.TableName = "tblEmployee";
            db.operation(employee);
            refreshEmployee();
        }

        private void btnEmployeeClean_Click(object sender, EventArgs e)
        {
            db.TableName = "tblEmployee";
            string id = dgvEmployee.SelectedRows[0].Cells[0].Value.ToString();
            db.operation(id);
            refreshEmployee();
        }


        void preview()
        {
            int searchPersonID=Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells[1].Value.ToString());
            foreach (DataGridViewRow item in dgvEmployeePerson.Rows)
            {
                DataGridViewCell hucre = item.Cells[0];
                if (Convert.ToInt32(hucre.Value.ToString())==searchPersonID)
                {
                    item.Selected = true;
                }

            }

            string searchDepartment = dgvEmployee.SelectedRows[0].Cells[3].Value.ToString();
            foreach (DataGridViewRow item in dgvEmployeeDepatment.Rows)
            {
                if (item.Cells[0].Value.ToString()==searchDepartment)
                {
                    item.Selected = true;
                }
            }
            string searchDegree = dgvEmployee.SelectedRows[0].Cells[4].Value.ToString();
            
            foreach (DataGridViewRow item in dgvEmployeeDegree.Rows)
            {
                if (item.Cells[0].Value.ToString() == searchDegree)
                {
                    item.Selected = true;
                    break;
                }
                else
                {
                    dgvEmployeeDegree.Rows[0].Selected = true;
                }
                
            }

        }

        private void dgvEmployee_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                preview();
            }
            catch (Exception)
            {

               // throw;
            }
        }
    }
}
