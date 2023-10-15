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
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public frmRegister()
        {
            InitializeComponent(); 
        }
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
                
            string[] ListofGender = new string[]
            {
                "Female",
                "Male"
            };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListofGender[i].ToString());
            }
        }

        public long StudentNumber(string studNum)
        {
            _StudentNo = long.Parse(studNum);
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid contact number format. Please input 11 digits only!");
                }
            }
            catch (Exception ie)
            {
                MessageBox.Show("Message: " + ie);
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + " " + FirstName + ", " + MiddleInitial + ".";
                }
                else
                {
                    throw new ArgumentNullException("Full name cannot be null! ");
                }
            }
            catch (Exception ae)
            {
                MessageBox.Show("Message: " + ae);
            }
            return _FullName;
        }

        public int Age(string age)
        {
            try
            {

                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else
                {
                    throw new OverflowException("Please input your real age!");
                }
            }
            catch (Exception oe)
            {
                MessageBox.Show("Message: " + oe);
            }
            return _Age;

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtStudentNo.Text))

                {
                    throw new FormatException();
                }
                else
                {

                    StudentInformationClass.SetFullname = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                    StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                    StudentInformationClass.SetProgram = cbPrograms.Text;

                    StudentInformationClass.SetGender = cbGender.Text;
                    StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                    StudentInformationClass.SetAge = Age(txtAge.Text);
                    StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy - MM - dd");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Message: " + fe);
            }
            finally
            {
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }

        }
    }
}

