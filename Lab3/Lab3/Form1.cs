using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDLib;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private CDList cdList = new CDList();
        public Form1()
        {
            InitializeComponent();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            AddNewForm form = new AddNewForm();
            form.Show(this);
        }

        public void AddCD(CD cd)
        {
            bool result = this.cdList.Add(cd);

            if (result == false)
            {
                
            }
        }

        public CD FindByID(string id)
        {
            return cdList.Find(id);
        }
    }
}
