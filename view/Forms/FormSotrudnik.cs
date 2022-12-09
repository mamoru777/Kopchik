using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLogic.Logic;
using DatabaseLogic.BindingModel;

namespace view.Forms
{
    public partial class FormSotrudnik : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private DolzhnostLogic dolLogic;
        private SotrudnikLogic sotLogic;
        private string auto = null;

        public FormSotrudnik()
        {
            InitializeComponent();
            dolLogic = new DolzhnostLogic();
            sotLogic = new SotrudnikLogic();
            var dolList = dolLogic.Read(null);
            var list = new List<string>();
            foreach (var dol in dolList)
            {
                list.Add(dol.Dol);
            }
            controlSelectedComboBoxList1.AddList(list);
        }
        private void LoadData()
        {
            if (id.HasValue)
            {
                try
                {
                    var view = sotLogic.Read(new SotrudnikBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFio.Text = view.FIO;
                        textBoxAuto.Text = view.Autobiography;
                        controlSelectedComboBoxList1.SelectedElement = view.Dol;
                        controlInputNullableDate1.Value = Convert.ToDateTime(view.dateupkval);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private bool Save()
        {
            if (textBoxFio.Text != string.Empty && controlSelectedComboBoxList1.SelectedElement != string.Empty && textBoxAuto.Text != string.Empty)
            {
                if (id != null)
                {
                    if (MessageBox.Show("Сохранить изменения в информации о сотруднике?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            sotLogic.CreateOrUpdate(new SotrudnikBindingModel()
                            {
                                Id = id,
                                FIO = textBoxFio.Text,
                                Autobiography = textBoxAuto.Text,
                                Dol = controlSelectedComboBoxList1.SelectedElement,
                                dateupkval = controlInputNullableDate1.Value.ToString()
                            }); 
                            return true;
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Введеная дата некорректна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    return false;
                }
                else
                {
                    if (MessageBox.Show("Сохранить информацию?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            sotLogic.CreateOrUpdate(new SotrudnikBindingModel()
                            {
                                Id = id,
                                FIO = textBoxFio.Text,
                                Autobiography = textBoxAuto.Text,
                                Dol = controlSelectedComboBoxList1.SelectedElement,
                                dateupkval = controlInputNullableDate1.Value.ToString()
                            });
                            return true;
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Введена некорректеная дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите значения");
                return false;
            }
        }
        private void FormSotrudnik_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
