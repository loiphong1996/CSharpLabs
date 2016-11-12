using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPratice
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();

            nationalcomboBox.Items.Add("vietnam");
        }

        private DataGridView GetDataGridView()
        {
            return (this.Owner as DetailForm).GetDataGridView();
        }

        private void addNewEmployee()
        {
            DataGridView employeeDataGridView = GetDataGridView();
            string gender = "";
            if (radioMale.Checked == true)
            {
                gender = " Male";
            }
            else if (radioFemale.Checked == true)
            {
                gender = "Female";
            }

            DataGridViewRow r = new DataGridViewRow();

            r.CreateCells(employeeDataGridView);
            r.SetValues(
                nameTextBox.Text,
                datePickerBirth.Value.ToShortDateString(),
                gender,
                nationalcomboBox.Text,
                phoneMaskedTextBox.Text,
                addressrichTextBox.Text,
                qualificationTextBox.Text,
                salaryTextBox.Text
                );

            employeeDataGridView.Rows.Add(r);
        }

        bool validateInput()
        {
            string name = nameTextBox.Text.Trim();
            bool bError = false;
            if (name.Length == 0)
            {
                errorProvider1.SetError(nameTextBox, "please enter your name");
                bError = true;
            }

            DateTime currDate = DateTime.Now;
            int currYear = currDate.Year;
            DateTime dob = datePickerBirth.Value;
            int birthYear = dob.Year;

            if (currYear - birthYear < 18)
            {
                errorProvider1.SetError(datePickerBirth, "Age must be greater then or equal to 18");
                bError = true;
            }
            if (radioMale.Checked == false && radioFemale.Checked == false)
            {
                errorProvider1.SetError(groupBox1, "Please select gender!");
                bError = true;
            }
            if (phoneMaskedTextBox.MaskCompleted == false)
            {
                errorProvider1.SetError(phoneMaskedTextBox, "please enter required digit!");
                bError = true;
            }
            if (nationalcomboBox.SelectedIndex < 0)
            {
                errorProvider1.SetError(nationalcomboBox, "please select National!");
                bError = true;
            }

            if (bError == true)
            {
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (validateInput() == true)
            {
                addNewEmployee();
            }
        }
    }
}
