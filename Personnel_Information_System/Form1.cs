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
        }
        void refreshDepartment()
        {
            db.TableName = "tblDepartment";
            db.operation();
            dgvDepartment.DataSource = db.Dt;
            dgvEmployeeDepatment.DataSource = db.Dt;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeNumber = txtEmployeeCode.Text;
            employee.EmployeeNameID =Convert.ToInt32( dgvEmployeePerson.SelectedRows[0].Cells[0].Value.ToString());
            employee.DateOfStart = dtpDateOfStart.Value;
            employee.DepartmantID = Convert.ToInt32(dgvEmployeeDepatment.SelectedRows[0].Cells[0].Value.ToString());
            employee.DegreeID = Convert.ToInt32(dgvEmployeeDegree.SelectedRows[0].Cells[0].Value.ToString());
            employee.WorkingStatus = ckbWorkingStatus.Checked;



        }
    }
}
