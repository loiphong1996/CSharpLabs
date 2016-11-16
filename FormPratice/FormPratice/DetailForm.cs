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

namespace FormPratice
{
    public partial class DetailForm : Form
    {
        private DataTable empDataTable;
        public DetailForm()
        {
            InitializeComponent();

//            empDataTable = new DataTable();
//            
//            DataColumn dc = new DataColumn();
//            dc.ColumnName = "fullNameColumn";
//            dc.Caption = "Full Name";
//            dc.DataType = typeof(string);
//            empDataTable.Columns.Add(dc);
//            //            ---------------            
//            dc.ColumnName = "dateOfBirthColumn";
//            dc.Caption = "Date of birth";
//            dc.DataType = typeof(DateTime);
//            empDataTable.Columns.Add(dc);
//            //            ---------------            
//            dc.ColumnName = "genderColumn";
//            dc.Caption = "Gender";
//            dc.DataType = typeof(string);
//            empDataTable.Columns.Add(dc);
//            //            ---------------            
//            dc.ColumnName = "nationalColumn";
//            dc.Caption = "National";
//            dc.DataType = typeof(string);
//            empDataTable.Columns.Add(dc);
//            //            ---------------            
//            dc.ColumnName = "phoneColumn";
//            dc.Caption = "Phone";
//            dc.DataType = typeof(string);
//            empDataTable.Columns.Add(dc);
//            //            ---------------            
//            dc.ColumnName = "addressColumn";
//            dc.Caption = "Address";
//            dc.DataType = typeof(string);
//            empDataTable.Columns.Add(dc);
//            //            ---------------            
//            dc.ColumnName = "qualificationColumn";
//            dc.Caption = "Qualification";
//            dc.DataType = typeof(string);
//            empDataTable.Columns.Add(dc);
//            //            ---------------            
//            dc.ColumnName = "salaryColumn";
//            dc.Caption = "Salary";
//            dc.DataType = typeof(string);
//            empDataTable.Columns.Add(dc);
            

        }

        public DataGridView GetDataGridView()
        {
            return employeeDataGridView;
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