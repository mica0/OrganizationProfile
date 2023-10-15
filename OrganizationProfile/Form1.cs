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
            if (string.IsNullOrEmpty(txtStudentNo.Text))
            {
                _StudentNo = long.Parse(studNum);
            }
            else
            {
                throw new FormatException();
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + " " + FirstName + ", " + MiddleInitial + ".";
            }
            else
            {
                throw new ArgumentNullException();
            }
            
            return _FullName;
        }
       
        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new OverflowException();
            }
            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                    StudentInformationClass.SetFullname = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                    StudentInformationClass.SetStudentNo = Convert.ToInt32(StudentNumber(txtStudentNo.Text));
                    StudentInformationClass.SetProgram = cbPrograms.Text;

                    StudentInformationClass.SetGender = cbGender.Text;
                    StudentInformationClass.SetContactNo = Convert.ToInt32(ContactNo(txtContactNo.Text));
                    StudentInformationClass.SetAge = Age(txtAge.Text);
                    StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy - MM - dd");

            }
            catch (FormatException)//student num
            {
                MessageBox.Show("Incorrect input, please try again!");
            }
            catch (IndexOutOfRangeException)//contact
            {
                MessageBox.Show("Index is out of  range.", "Invalid input, please input 11 digit only.");
            }
            catch (ArgumentNullException)//fullname
            {
                MessageBox.Show("Please full in the detials needed");
            }
            catch (OverflowException) //age
            {
                MessageBox.Show("Invalid input.","Please enter your true age!" );
            }
            finally 
            {
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            
        }
    }
}

