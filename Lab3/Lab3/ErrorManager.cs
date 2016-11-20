using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    class ErrorManager
    {
        private Dictionary<Control, ErrorProvider> dictionary;

        public void Add(Control control)
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<Control, ErrorProvider>();
            }
            dictionary.Add(control, new ErrorProvider());

        }


        public void ShowError(Control control, string errorMessage)
        {
            ErrorProvider errorProvider = GetErrorProvider(control);
            if (errorProvider == null)
            {
                Add(control);
                errorProvider = dictionary[control];
            }
            errorProvider.SetError(control, errorMessage);
        }

        public bool IsHavingError(Control control)
        {
            ErrorProvider errorProvider = dictionary?[control];

            if (errorProvider != null)
            {
                if (errorProvider.GetError(control) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public void clear(Control control)
        {
            ErrorProvider errorProvider = GetErrorProvider(control);
            if (errorProvider == null)
            {
                Add(control);
                errorProvider = dictionary[control];
            }
            errorProvider.Clear();
        }

        private ErrorProvider GetErrorProvider(Control control)
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<Control, ErrorProvider>();
                return null;
            }
            else
            {
                try
                {
                    return dictionary[control];
                }
                catch (KeyNotFoundException)
                {
                    return null;
                }
            }
        }

        

        public void ClearAll()
        {
            foreach (KeyValuePair<Control, ErrorProvider> pair in dictionary)
            {
                ErrorProvider errorProvider = pair.Value;
                errorProvider.Clear();
            }
        }
    }
}
