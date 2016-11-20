using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;


namespace FormPratice
{
    public partial class DetailForm : Form
    {
        private DataTable empDataTable;

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private string connectionString =
            @"server=PHONGTLSE61770;database=EmployeeDB;uid=sa;pwd=1234";

        public DetailForm()
        {
            InitializeComponent();

            con = new SqlConnection();
            con.ConnectionString = connectionString;

            LoadEmployee();
            
        }

        public DataGridView GetDataGridView()
        {
            return employeeDataGridView;
        }

        private void LoadEmployee()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Employees";
                dr = cmd.ExecuteReader();
                employeeDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(employeeDataGridView);
                    r.SetValues(
                        dr[0],
                        dr[1],
                        dr[2],
                        dr[3],
                        dr[4],
                        dr[5],
                        dr[6],
                        dr[7],
                        dr[8]
                    );

                    employeeDataGridView.Rows.Add(r);
                }
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.Owner = this;
            inputForm.ShowDialog();
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row!");
                return;
            }
            DataGridViewRow r = employeeDataGridView.SelectedRows[0];

            InputForm inputForm = new InputForm(false);
            inputForm.Owner = this;
            inputForm.setInfo(r);
            inputForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure ?!", "Confirm",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow r = employeeDataGridView.SelectedRows[0];
                employeeDataGridView.Rows.Remove(r);

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

            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                JArray array = new JArray();
                
                foreach (DataGridViewRow row in employeeDataGridView.Rows)
                {
                    string fullname = row.Cells["NameColumn"].Value.ToString();
                    string dateOfBirth = row.Cells["DateOfBirthColumn"].Value.ToString();
                    string gender = row.Cells["GenderColumn"].Value.ToString();
                    string national = row.Cells["nationalColumn"].Value.ToString();
                    string phone = row.Cells["phoneColumn"].Value.ToString();
                    string address = row.Cells["addressColumn"].Value.ToString();
                    string qualification = row.Cells["qualificationColumn"].Value.ToString();
                    string salary = row.Cells["salaryColumn"].Value.ToString();

                    JObject jobj = new JObject();
                    jobj.Add("fullname", fullname);
                    jobj.Add("dateOfBirth", dateOfBirth);
                    jobj.Add("gender", gender);
                    jobj.Add("national", national);
                    jobj.Add("phone", phone);
                    jobj.Add("address", address);
                    jobj.Add("qualification", qualification);
                    jobj.Add("salary", salary);

                    array.Add(jobj);
                }

                string filename = saveFileDialog1.FileName;
                using (StreamWriter writer = new StreamWriter(filename))
                {
                   writer.Write(array.ToString());
                }

            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                JArray jArray = new JArray();

                string filename = openFileDialog1.FileName;
                using (StreamReader reader = new StreamReader(filename))
                {
                    string data = reader.ReadToEnd();
                    jArray = JArray.Parse(data);
                }

                if (jArray.Count > 0)
                {
                    employeeDataGridView.Rows.Clear();
                    foreach (JToken token in jArray)
                    {
                        string fullname = token.Value<string>("fullname");
                        string dateOfBirth = token.Value<string>("dateOfBirth");
                        string gender = token.Value<string>("gender");
                        string national = token.Value<string>("national");
                        string phone = token.Value<string>("phone");
                        string address = token.Value<string>("address");
                        string qualification = token.Value<string>("qualification");
                        string salary = token.Value<string>("salary");

                        DataGridViewRow r = new DataGridViewRow();
                        r.CreateCells(employeeDataGridView);
                        r.SetValues(
                            fullname,
                            dateOfBirth,
                            gender,
                            national,
                            phone,
                            address,
                            qualification,
                            salary
                            );

                        employeeDataGridView.Rows.Add(r);
                    }
                }
                
            }
        }
    }
}