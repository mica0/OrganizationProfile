using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {

        StudentInformationClass sc = new StudentInformationClass();
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblStudentNo.Text = sc.SetStudentNo.ToString();
            lblName.Text = sc.SetFullname;
            lblProgram.Text = sc.SetProgram;
            lblBirthday.Text = sc.SetBirthday;
            lblGender.Text = sc.SetGender;
            lblContactNo.Text = sc.SetContactNo.ToString();
            lblAge.Text = sc.SetAge.ToString();
        }
    }
}
