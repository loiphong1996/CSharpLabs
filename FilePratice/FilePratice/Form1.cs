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

namespace FilePratice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(this, message);
        }

        private void createDirBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string path = getPath();
                
                FileManager.createDir(path);

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string path = getPath();

                List<string> nameList = FileManager.listContent(path);
                contentRichTextBox.Text = "";
                foreach (string s in nameList)
                {
                    contentRichTextBox.AppendText(s+Environment.NewLine);
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void createBtn_Click(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string path = getPath();

                string content = FileManager.readFile(path);

                contentRichTextBox.Text = content;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        public string getPath()
        {
            string dir = getDirPath();
            string name = getNamePath();

            return Path.Combine(dir, name);
        }

        private string getDirPath()
        {
            return pathTextBox.Text;
        }

        private string getNamePath()
        {
            return nameTextBox.Text;
        }
    }
}
