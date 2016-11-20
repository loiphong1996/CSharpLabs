using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private SqlConnection con;
        private SqlCommand cmd;
        private int Id;
        
        private string connectionString =
            @"server=PHONGTLSE61770;database=EmployeeDB;uid=sa;pwd=1234";
        public InputForm(bool bAdd = true)
        {
            InitializeComponent();
            this.bAdd = bAdd;
            if (bAdd == false)
                addButton.Text = "Save";

            nationalcomboBox.Items.Add("Singapore");
            nationalcomboBox.Items.Add("Japan");
            nationalcomboBox.Items.Add("Vietnam");
            nationalcomboBox.Items.Add("America");

            con = new SqlConnection();
            con.ConnectionString = connectionString;
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
                gender = " M";
            }
            else if (radioFemale.Checked == true)
            {
                gender = "F";
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
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "[InsertEmployee]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameterCollection paramCollection = cmd.Parameters;
                paramCollection.Add("@FullName", SqlDbType.VarChar, 50);
                paramCollection.Add("@DOB", SqlDbType.DateTime);
                paramCollection.Add("@Gender", SqlDbType.Char, 1);
                paramCollection.Add("@National", SqlDbType.VarChar, 50);
                paramCollection.Add("@Phone", SqlDbType.VarChar, 50);
                paramCollection.Add("@Address", SqlDbType.VarChar, 50);
                paramCollection.Add("@Qualification", SqlDbType.VarChar, 50);
                paramCollection.Add("@Salary", SqlDbType.Money);

                paramCollection["@FullName"].Value = nameTextBox.Text;
                paramCollection["@DOB"].Value = datePickerBirth.Value;
                paramCollection["@Gender"].Value = gender;
                paramCollection["@National"].Value = nationalcomboBox.Text;
                paramCollection["@Phone"].Value = phoneMaskedTextBox.Text;
                paramCollection["@Address"].Value = addressrichTextBox.Text;
                paramCollection["@Qualification"].Value = qualificationTextBox.Text;
                paramCollection["@Salary"].Value = salaryTextBox.Text;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        private void exeSql(string sql)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteReader();

            }
            finally
            {
                con.Close();
            }
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
                gender = " M";
            }
            else if (radioFemale.Checked == true)
            {
                gender = "F";
            }

            DataGridViewRow r = employeeDataGridView.SelectedRows[0];
            r.SetValues(
                Id,
                nameTextBox.Text,
                datePickerBirth.Value.ToShortDateString(),
                gender,
                nationalcomboBox.Text,
                phoneMaskedTextBox.Text,
                addressrichTextBox.Text,
                qualificationTextBox.Text,
                salaryTextBox.Text
                );

            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "[UpdateEmployee]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameterCollection paramCollection = cmd.Parameters;
                paramCollection.Add("@ID", SqlDbType.Int);
                paramCollection.Add("@FullName", SqlDbType.VarChar, 50);
                paramCollection.Add("@DOB", SqlDbType.DateTime);
                paramCollection.Add("@Gender", SqlDbType.Char, 1);
                paramCollection.Add("@National", SqlDbType.VarChar, 50);
                paramCollection.Add("@Phone", SqlDbType.VarChar, 50);
                paramCollection.Add("@Address", SqlDbType.VarChar, 50);
                paramCollection.Add("@Qualification", SqlDbType.VarChar, 50);
                paramCollection.Add("@Salary", SqlDbType.Money);

                paramCollection["@ID"].Value = Id;
                paramCollection["@FullName"].Value = nameTextBox.Text;
                paramCollection["@DOB"].Value = datePickerBirth.Value;
                paramCollection["@Gender"].Value = gender;
                paramCollection["@National"].Value = nationalcomboBox.Text;
                paramCollection["@Phone"].Value = phoneMaskedTextBox.Text;
                paramCollection["@Address"].Value = addressrichTextBox.Text;
                paramCollection["@Qualification"].Value = qualificationTextBox.Text;
                paramCollection["@Salary"].Value = salaryTextBox.Text;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

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
            Id = Int32.Parse(row.Cells["IdColumn"].Value.ToString());
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
