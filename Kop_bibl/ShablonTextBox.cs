using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Kop_bibl
{
    public partial class ShablonTextBox : UserControl
    {
        public ShablonTextBox()
        {
            InitializeComponent();
            toolTip.SetToolTip(textBox, example);
            textBox.TextChanged += (sender, e) => _event?.Invoke(sender, e);
            
        }
        private string example = "+79374561005";
        private event EventHandler _event;
        private string pattern = @"^\+*\d{1,11}(-\d{3}-\d{3}-\d{2,4}(-\d{2})*)*$";
        public string Pattern { get { return pattern; } set { pattern = value; } }
        public string Value
        {
           get
            { 
                if (!String.IsNullOrEmpty(textBox.Text) && !Regex.IsMatch(textBox.Text, Pattern))
                {
                    throw new ArgumentException();
                }
                return textBox.Text; 
            }
            set         
            {
                if (Regex.IsMatch(value, Pattern))
                    textBox.Text = value; 
            }
        }

        public event EventHandler SelectedTextChanged
        {
            add
            {
                _event += value;
            }
            remove
            {
                _event -= value;
            }
        }
        public void SetExample(string value)
        {
            if (!String.IsNullOrEmpty(value) && !Regex.IsMatch(value, Pattern))
            {
                example = value;
                toolTip.SetToolTip(textBox, value);
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            textBox.BackColor =
                Color.FromArgb(random.Next(256),
                random.Next(256), random.Next(256));
        }
    }
}
