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
using DatabaseLogic.BindingModel;
using DatabaseLogic.ViewModel;
using DatabaseLogic.Logic;
using DatabaseLogic.Model;
using view.Forms;
using ControlsLibraryNet50.Data;
using ComponentsLibraryNet50.DocumentWithChart;
using ComponentsLibraryNet50.DocumentWithContext;
using ComponentsLibraryNet50.DocumentWithTable;
using ComponentsLibraryNet50.Models;
using ControlsLibraryNet50.Models;

namespace view
{
    public partial class MainForm : Form
    {

        private SotrudnikLogic sotLogic;
        private DolzhnostLogic dolLogic;

        /*private List<DataTa>
        private List<>
        private List<>*/
        public MainForm()
        {
            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("Dol");
            nodeNames.Enqueue("dateupkval");
            nodeNames.Enqueue("Id");
            nodeNames.Enqueue("FIO");
            var treeConfig = new DataTreeNodeConfig { NodeNames = nodeNames };
            InitializeComponent();
            controlDataTreeTable1.LoadConfig(treeConfig);
            sotLogic = new SotrudnikLogic();
            ReloadData();
        }
        private void ReloadData()
        {
            controlDataTreeTable1.Clear();
            var data = sotLogic.Read(null);
            if (data.Count > 0)
            {
                controlDataTreeTable1.AddTable(data);
            }
            //controlDataTreeTable1.Select();
        }
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.A:
                    AddNewElement();
                    break;
                case Keys.U:
                    UpdateElement();
                    break;
                case Keys.D:
                    DeleteElement();
                    break;
                case Keys.S:
                    CreateBigDataDoc();
                    break;
                case Keys.T:
                    CreateTableDoc();
                    break;
                case Keys.C:
                    CreatePieDoc();
                    break;
            }
        }
        private void AddNewElement()
        {
            var form = new FormSotrudnik();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ReloadData();
            }
        }
        private void UpdateElement()
        {
            //int? element = controlDataTreeTable1.GetSelectedObject<SotrudnikViewModel>().Id;
            //if (controlDataTreeTable1.GetSelectedObject<SotrudnikViewModel>().dateupkval == null)
            var element = controlDataTreeTable1.GetSelectedObject<SotrudnikBindingModel>();//<SotrudnikViewModel>();
            //controlDataTreeTable1.
            /*if (element.dateupkval == "")
            {
                //Convert.ToDateTime(element.dateupkval);
                element.dateupkval = null;
                DateTime.Parse(element.dateupkval);
                //element.dateupkval = null;
            }
            else
            {
                Convert.ToDateTime(element.dateupkval);
            }*/

            if (element == null)
            {
                MessageBox.Show("Нет выбранного элемента", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = new FormSotrudnik { Id = Convert.ToInt32(element.Id) };
            if (form.ShowDialog() == DialogResult.OK)
            {
                ReloadData();
            }
        }
        private void DeleteElement()
        {
            if (MessageBox.Show("Удалить выбранный элемент", "Удаление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            var element = controlDataTreeTable1.GetSelectedObject<SotrudnikViewModel>();
            if (element == null)
            {
                MessageBox.Show("Нет выбранного элемента", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sotLogic.Delete(new SotrudnikBindingModel { Id = element.Id});
            ReloadData();
        }
        private void CreateBigDataDoc()
        {
            var list2 = sotLogic.Read(null);
            /*List<Sotrudnik> list1 = new List<Sotrudnik>();
            list1.Add*/
            List<string> list = new List<string>();
            foreach (var sot in list2)
            {
                if (sot.dateupkval != null)
                {
                    list.Add(sot.FIO + " " + sot.Autobiography);
                }
            }
            BackColor = Color.White;
            ComponentDocumentWithContextTextPdf componentDocumentWithContextTextPdf = new ComponentDocumentWithContextTextPdf();
            componentDocumentWithContextTextPdf.CreateDoc(new ComponentDocumentWithContextTextConfig
            {
                FilePath = "D:\\testPdf\\firstComponent3Lab.pdf",
                Header = "Сотрудники проходившие повышение квалификации",
                Paragraphs = list/*new List<string>
                {
                    list
                }*/
            }); 
        }
        private void CreateTableDoc()
        {
            var list = sotLogic.Read(null);
            List<Sotrudnik> list2 = new List<Sotrudnik>();
            foreach(var sot in list)
            {
                if (sot.dateupkval.ToString() == "")
                {
                    //sot.dateupkval = "не проходил";
                    list2.Add(new Sotrudnik
                    {
                        FIO = sot.FIO,
                        Autobiography = sot.Autobiography,
                        dateupkval = Convert.ToDateTime(sot.dateupkval)/*"Не проходил"*/,
                        Dol = sot.Dol
                    });
                }
                else
                {
                    list2.Add(new Sotrudnik
                    {
                        FIO = sot.FIO,
                        Autobiography = sot.Autobiography,
                        dateupkval = Convert.ToDateTime(sot.dateupkval),
                        Dol = sot.Dol
                    });
                }
                
            }
            BackColor = Color.White;
            ComponentDocumentWithTableMultiHeaderExcel componentDocumentWithTableMultiHeaderExcel = new ComponentDocumentWithTableMultiHeaderExcel();
            componentDocumentWithTableMultiHeaderExcel.CreateDoc(new ComponentDocumentWithTableHeaderDataConfig<Sotrudnik>
            {
                FilePath = "D:\\testPdf\\secondComponent3Lab.xlsx",
                Header = "Таблица эксель",
                ColumnsRowsWidth = new List<(int, int)> { (5, 5), (10, 5), (10, 0), (15, 0)},

                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "Идентификатор", "Id"),
                    (1, 0, "ФИО", "FIO"),
                    (2, 0, "Должность", "Dol"),
                    (3, 0, "Дата повышения квалификации", "dateupkval")
                },
                Data = list2
            });
        }
        private void CreatePieDoc()
        {
            BackColor = Color.White;
            /*var list1 = dolLogic.Read(null);
            var list2 = sotLogic.Read(null);
            List<(string Dol, double vaule)> list3 = new List<(string Dol, double vaule)>();
            foreach (var item in list2)
            {

            }*/
            ComponentDocumentWithChartPieWord componentDocumentWithChartPieWord = new ComponentDocumentWithChartPieWord();
            componentDocumentWithChartPieWord.CreateDoc(new ComponentDocumentWithChartConfig
            {
                FilePath = "D:\\testPdf\\thirdComponent3Lab.docx",
                Header = "Заголовок",
                ChartTitle = "Круговая диаграмма",
                LegendLocation = ComponentsLibraryNet50.Models.Location.Bottom,
                Data = ExcelData()/*new Dictionary<string, List<(string Dol, double Value)>>*/
                
            }); 

        }
        private Dictionary<string, List<(int, double)>> ExcelData()
        {
            var list = sotLogic.Read(null);
            var list_product = new Dictionary<string, int>();
            foreach (var item in list)
            {
                if (item.dateupkval.ToString() == "")
                {
                    if (list_product.ContainsKey(item.Dol))
                        list_product[item.Dol]++;
                    else
                    {
                        list_product.Add(item.Dol, 1);
                    }
                }
            }
            var list_changed = new Dictionary<string, List<(int, double)>>();

            var new_list = new List<(int, double)>();
            var i = 0;
            foreach (var new_item in list_product)
            {
                i++;
                new_list.Add((i, new_item.Value));
            }

            list_changed.Add("Серия", new_list);


            return list_changed;
        }
        private void простойДокументCtrlSToolStripMenuItem_Click(object sender, EventArgs e) =>
        CreateBigDataDoc();

        private void документСТаблицейCtrlTToolStripMenuItem_Click(object sender, EventArgs e) =>
        CreateTableDoc();
        
        private void диаграммаCtrlCToolStripMenuItem_Click(object sender, EventArgs e) =>
        CreatePieDoc();

        private void добавитьCtrlAToolStripMenuItem_Click(object sender, EventArgs e) =>
        AddNewElement();

        private void изменитьCtrlUToolStripMenuItem_Click(object sender, EventArgs e) =>
        UpdateElement();

        private void удалитьCtrlDToolStripMenuItem_Click(object sender, EventArgs e) =>
        DeleteElement();

        private void продуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormDolzhnost();
            form.ShowDialog();
        }
    }
}
