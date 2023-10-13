using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegister : Form
    {
        StudentInformationClass sc = new StudentInformationClass();
        public frmRegister()
        {
            InitializeComponent(); 
        }

        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        private void frmRegister_Load(object sender, EventArgs e)
        {
            string[] ListofProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountacy",
                "BS in Hospitality Management",
                "BS inTourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListofProgram[i].ToString());
            }
        }

        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            sc.SetFullname = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            sc.SetStudentNo = StudentNumber(txtStudentNo.Text);
            sc.SetProgram = cbPrograms.Text;

            sc.SetGender = cbGender.Text;
            sc.SetContactNo = ContactNo(txtContactNo.Text);
            sc.SetAge = Age(txtAge.Text);
            sc.SetBirthday = datePickerBirthday.Value.ToString("yyyyMM-dd");

            frmConfirmation frm = new frmConfirmation();
            frm.ShowDialog();
        }
    }
}

