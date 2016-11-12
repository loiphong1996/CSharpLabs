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
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();

            
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
    }
}
