using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kop_bibl.NonVisualComponent;
using Kop_bibl.NonVisualComponent.HelperModels;
using view.Model;

namespace view
{
    public partial class MainForm : Form
    {
        List<Order> orderList = new List<Order> {
            new Order{ BuyerName = "Kate Taurielke",
            ProductName = "Table",
            Price = 100
            },
            new Order{ BuyerName = "Andrey Kutygin",
            ProductName = "Chair",
            Price = 50
            },
            new Order{ BuyerName = "Evgeniy Sergeev",
            ProductName = "Laptop",
            Price = 1000
            }
        };
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
            //myComboBox1.FillList = "gavno";
            //myComboBox1.FillList = "gavno1";
            //myComboBox1.FillList = "gavno2";
            //myComboBox1.FillList = list1;
            //
        }
            private void button1_Click(object sender, EventArgs e)
            {
                string[] str = new string[3];
                str[0] = "Hello World";
                str[1] = "its me your creator";
                str[2] = "youre so young now";
                BigTextPdfComponent tc = new BigTextPdfComponent();
                tc.save("D:\\testPdf\\firstComponent.pdf", "Question and answer", str);
            }

            private void button2_Click(object sender, EventArgs e)
            {
                CustomTablePdf ctc = new CustomTablePdf();
                string folder = "D:\\testPdf\\secondComponent.pdf";
                string title = "Test";
            List<string> ColTitles = new List<string>();
            ColTitles.Add("BuyerName");
            ColTitles.Add("ProductName");
            ColTitles.Add("Price");
            List<string> ColTitles2 = new List<string>();
            ColTitles2.Add("Product");
            List<Tuple<int, int>> MergeCells = new List<Tuple<int, int>>();
            MergeCells.Add(new Tuple<int,int>(1, 2));
            /*List<PdfColumnInfo> columns = new List<PdfColumnInfo>();
            PdfRowInfo[] rows = new PdfRowInfo[2];

            columns.Add(new PdfColumnInfo { Name = "BuyerName", PropertyName = "BuyerName" });
            columns.Add(new PdfColumnInfo { Name = "ProductName", PropertyName = "ProductName" });
            columns.Add(new PdfColumnInfo { Name = "Price", PropertyName = "Price" });

            rows[0] = new PdfRowInfo() { Height = 50 };
            rows[1] = new PdfRowInfo() { Height = 50 };

            ctc.SaveTable(folder, title, columns, rows, orderList);*/
            ctc.SaveTable(folder, title, ColTitles, ColTitles2, MergeCells ,orderList);
            }
            private void button3_Click(object sender, EventArgs e)
        {
            LinearDiagramPdfComponent lpc = new LinearDiagramPdfComponent();
            string folder = "D:\\testPdf\\thirdComponent.pdf";
            string title = "Test";
            lpc.SaveDiagram(title, folder);
        }
    }
}
