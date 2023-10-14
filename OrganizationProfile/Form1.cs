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

    public long StudentNumber(string studNum)
    {
            try
            {
                if (string.IsNullOrEmpty(studNum))
                {
                    _StudentNo = long.Parse(studNum);
                }
                else
                {
                    throw new FormatException("Incorrect Input, please try again!");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            finally 
            {
                MessageBox.Show("Please input Student Number");
            }
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
                    throw new IndexOutOfRangeException("Index of out range, please try again!");
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                MessageBox.Show(ie.Message);
            }
            finally
            {
                MessageBox.Show("Input 11 index only!");
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
                    throw new ArgumentNullException("Empty textbox, please input lastname, firstname or middleInitial!");
                }
            }
            catch (ArgumentNullException ae)
            {
              //  MessageBox.Show(ae.Message);
            }
            finally 
            {
               // MessageBox.Show("Do not leave the textbox empty!");
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
                    throw new OverflowException("Sorry, your age input was incorrect. Please try again!");
                }
            }
            catch (OverflowException oe)
            {
             //   MessageBox.Show(oe.Message);
            }
            finally
            {
               // MessageBox.Show("Enter integer only!");
            }
            return _Age;
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
                "Male",
                "Female"
            };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListofGender[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            StudentInformationClass.SetFullname = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;

            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyyMM-dd");

            frmConfirmation frm = new frmConfirmation();
            frm.ShowDialog();
        }
    }
}

