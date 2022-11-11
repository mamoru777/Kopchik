using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Section = MigraDoc.DocumentObjectModel.Section;
using System.IO;
using System.Reflection;
using Kop_bibl.NonVisualComponent.HelperModels;
//using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;

namespace Kop_bibl.NonVisualComponent
{
    public partial class CustomTablePdf : Component
    {
        public CustomTablePdf()
        {
            InitializeComponent();
        }

        public CustomTablePdf(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void SaveTable<T>(string folder, string docTitle, /*List<PdfColumnInfo> columns,*/ List<string> ColFields, List<string> ColFields2, List<Tuple<int, int>> MergeCells,
           /*PdfRowInfo[] rows,*/ List<T> objList)
        {
            IsDataNotEmpty(objList);
            Document document = new Document();
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(docTitle);
            var table = document.LastSection.AddTable();
            table.Borders.Width = 0.75;
            bool widthsExist = true;
            
            
            var colvololumns = objList[0].GetType().GetProperties();
            foreach (var column in colvololumns)
            {
                table.AddColumn().Format.Alignment = ParagraphAlignment.Center;
            }
            
            foreach (var item in objList)
            {
                table.AddRow();
            }
            for (int i = 0; i < 2; i++)
            {
                table.AddRow();
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                table.Rows[1].Cells[i].AddParagraph().AddText(ColFields[i]);
            }

            for (int i = 0; i < objList.Count; i++)
            {
                var properties = objList[i].GetType().GetProperties();
                for (int j = 0; j < properties.Length; j++)
                {
                    table.Rows[i + 2].Cells[j].AddParagraph().AddText(properties[j].GetValue(objList[i]).ToString());
                }
            }
            for (int i = 0; i < MergeCells.Count; i++)
            {
                Tuple<int, int> tuple = MergeCells[i];
                table.Rows[0].Cells[tuple.Item1].MergeRight = tuple.Item2-tuple.Item1;
                table.Rows[0].Cells[tuple.Item1].AddParagraph().AddText(ColFields2[i].ToString());  
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Rows[0].Cells[i].Elements.IsNull())
                {
                    table.Rows[0].Cells[i].MergeDown = 1;
                    table.Rows[0].Cells[i].AddParagraph().AddText(ColFields[i].ToString());
                    
                }
                    
            }
            MessageBox.Show("1" + table.Rows[0].Cells[0].ToString() + "2");
   

            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(folder);
        }
        
        private void IsDataNotEmpty<T>(List<T> objList)
        {
            if (objList.Count == 0) throw new Exception("list is empty");
        }

        private void AreColumnsFull(List<PdfColumnInfo> columns)
        {
            foreach (PdfColumnInfo column in columns)
            {
                if (column.Name == null || column.PropertyName == null)
                {
                    throw new Exception("fill in the columns");
                }
            }
        }
    }
}
