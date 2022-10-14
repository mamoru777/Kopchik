using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kop_bibl
{
    public partial class MyComboBox : UserControl
    {
        public MyComboBox()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) => _event?.Invoke(sender, e);
        }

        private event EventHandler _event;
        public event EventHandler SelectedIndexChanged
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
        private int checkI = -1;
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            comboBox.BackColor =
                Color.FromArgb(random.Next(256),
                random.Next(256), random.Next(256));
            checkI = comboBox.SelectedIndex;
        }

        public string SelectedElement
        {
            get
            {
                if (comboBox.SelectedItem == null)
                    return string.Empty;
                return comboBox.SelectedItem.ToString();
            }
            set
            {
                comboBox.SelectedItem = value;
            }
        }

        public ComboBox.ObjectCollection FillList
        {
            get
            {
                return comboBox.Items;
            }
        }
        public void Clear()
        {
            comboBox.DataSource = null;
        }
    }
}
