using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            List<string> list1 = new List<string>();
            list1.Add("Gavno");
            list1.Add("Chort");
            list1.Add("Petuh");
            myComboBox1.FillList = "gavno";
            myComboBox1.FillList = "gavno1";
            myComboBox1.FillList = "gavno2";
            //myComboBox1.FillList = list1;               
        }
    }
}
