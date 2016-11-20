using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDLib;

namespace Lab3
{
    public partial class AddNewForm : Form
    {
        public readonly string edit = "EDIT";
        public readonly string add = "ADD";
        private string aciton = "";
        private ErrorManager _errorManager = new ErrorManager();
        public AddNewForm(string action = "ADD")
        {
            InitializeComponent();
            this.aciton = action;
            actionBtn.Text = action;
            this.Text = action;
            genreCombobox.SelectedIndex = 0;

            actionBtn.MouseEnter += idTextBox_TextChanged;
            actionBtn.MouseEnter += albumTextBox_TextChanged;
            actionBtn.MouseEnter += singerTextBox_TextChanged;
            actionBtn.MouseEnter += durationTextBox_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (this.aciton.Equals(add))
            {
                Add();
            }
            else
            {
                Edit();
            }
        }

        private CD GetCD()
        {
            return null;
        }



        private void Add()
        {
            
        }

        public void Edit()
        {
            
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex=  new Regex("^.+$");
            RegexValidate(idTextBox, regex, "ID Cant be empty!");

            if (_errorManager.IsHavingError(idTextBox))
            {
                string id = idTextBox.Text;
                CD cd = GetOwner().FindByID(id);
                if (cd != null)
                {
                    _errorManager.ShowError(idTextBox,"CD["+id+"] already exist!");
                }
            }
        }

        private void albumTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^.+$");
            RegexValidate(albumTextBox, regex, "Album can't be empty!");
        }

        private void singerTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^.+$");
            RegexValidate(singerTextBox, regex, "Singer can't be empty!");
        }

        private void durationTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^(\\d)+$");
            RegexValidate(durationTextBox,regex, "Duration must be integer!");
        }

        private void songTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void addSongBtn_Click(object sender, EventArgs e)
        {
            string song = songTextBox.Text;
            songListView.Items.Remove();    
        }


        private void deleteSongBtn_Click(object sender, EventArgs e)
        {

            string song = songTextBox.Text;
            foreach (object item in songListView.SelectedItems)
            {
                string song = item as string;
                
            }
        }

        private int 

        private void songListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void genreCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegexValidate(Control control, Regex regex,string errorMessage)
        {
            
            string text = control.Text;
            if (regex.IsMatch(text))
            {
                _errorManager.clear(control);
            }
            else
            {
                _errorManager.ShowError(control, errorMessage);
            }
        }

        private Form1 GetOwner()
        {
            if (Owner is Form1)
            {
                return Owner as Form1;
            }
            return null;
        }

        
    }
}
