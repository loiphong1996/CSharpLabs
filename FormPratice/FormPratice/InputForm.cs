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
        private bool bAdd;
        public InputForm(bool bAdd = true)
        {
            InitializeComponent();
            this.bAdd = bAdd;
            if (bAdd == false)
                addButton.Text = "Save";

            nationalcomboBox.Items.Add("vietnam");
            nationalcomboBox.Items.Add("america");
        }

        private DataGridView GetDataGridView()
        {
            return (Owner as DetailForm).GetDataGridView();
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
            if (bAdd)
            {
                if (validateInput() == true)
                {
                    addNewEmployee();
                }
            }
            else
            {
                updateInfo();
            }
            
        }

        private void updateInfo()
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

            DataGridViewRow r = employeeDataGridView.SelectedRows[0];
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
            

        }

        public void setInfo(
            string fullname,string dateOfBirth,string gender,string national,
            string phone, string address,string qualification, string salary)
        {
            nameTextBox.Text = fullname;
            datePickerBirth.Value = DateTime.Parse(dateOfBirth);
            if (gender.Equals("male"))
                radioMale.Checked = true;
            else
                radioFemale.Checked = true;
            nationalcomboBox.SelectedItem = national;
            phoneMaskedTextBox.Text = phone;
            addressrichTextBox.Text = address;
            qualificationTextBox.Text = qualification;
            salaryTextBox.Text = salary;

        }

        public void setInfo(DataGridViewRow row)
        {
            string fullname = row.Cells["NameColumn"].Value.ToString();
            string dateOfBirth = row.Cells["DateOfBirthColumn"].Value.ToString();
            string gender = row.Cells["GenderColumn"].Value.ToString();
            string national = row.Cells["nationalColumn"].Value.ToString();
            string phone = row.Cells["phoneColumn"].Value.ToString();
            string address = row.Cells["addressColumn"].Value.ToString();
            string qualification = row.Cells["qualificationColumn"].Value.ToString();
            string salary = row.Cells["salaryColumn"].Value.ToString();


            setInfo(fullname,dateOfBirth,gender,national,phone,address,qualification,salary);
        }
    }
}
