using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel_Information_System
{
    class Personel_Information
    {
    }

    public class Person
    {
        private int id;

        public int ID
        {
            get { return id; }
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TcNumber { get; set; }
        public DateTime Birthday { get; set; }

    }

    public class Employee
    {
        public string EmployeeNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public int DepartmantID { get; set; }
        public int DegreeID { get; set; }
        public bool WorkingStatus { get; set; }
        public int EmployeeNameID { get; set; }
        
    }
    public class Departman
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string DepartmantName { get; set; }
    }

    public class Unvan
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string DegreeName { get; set; }
    }










}
