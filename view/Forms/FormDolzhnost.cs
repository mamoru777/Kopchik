using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLogic.BindingModel;
using DatabaseLogic.Logic;


namespace view.Forms
{
    public partial class FormDolzhnost : Form
    {
        DolzhnostLogic logic;
        List<DolzhnostBindingModel> list;
        public FormDolzhnost()
        {
            InitializeComponent();
            logic = new DolzhnostLogic();
            list = new List<DolzhnostBindingModel>();
        }
        private void LoadData()
        {
            try
            {
                var list1 = logic.Read(null);
                list.Clear();
                foreach (var item in list1)
                {
                    list.Add(new DolzhnostBindingModel
                    {
                        Id = item.Id,
                        Dol = item.Dol
                    });
                }
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormDolzhnost_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = (string)dataGridView1.CurrentRow.Cells[1].Value;
            if (!string.IsNullOrEmpty(typeName))
            {
                if (dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    logic.CreateOrUpdate(new DolzhnostBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                        Dol = (string)dataGridView1.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
                else
                {
                    logic.CreateOrUpdate(new DolzhnostBindingModel()
                    {
                        Dol = (string)dataGridView1.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    list.Add(new DolzhnostBindingModel());
                    dataGridView1.DataSource = new List<DolzhnostBindingModel>(list);
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
                    return;
                }
                if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value != null)
                {
                    list.Add(new DolzhnostBindingModel());
                    dataGridView1.DataSource = new List<DolzhnostBindingModel>(list);
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Удалить выбранный элемент", "Удаление",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    logic.Delete(new DolzhnostBindingModel() { Id = (int)dataGridView1.CurrentRow.Cells[0].Value });
                    LoadData();
                }
            }
        }
    }
}