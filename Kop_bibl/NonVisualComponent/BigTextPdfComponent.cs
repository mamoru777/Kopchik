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
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;
using static System.Text.CodePagesEncodingProvider;
using MigraDoc.RtfRendering;

namespace Kop_bibl.NonVisualComponent
{

    public partial class BigTextPdfComponent : Component
    {
        
        public BigTextPdfComponent()
        {
            InitializeComponent();
        }

        public BigTextPdfComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void save(string folder, string title, string[] stroki)
        {
            
            var document = new Document();
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(title);
            paragraph.Format.SpaceAfter = 15;
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.Format.Font.Bold = true;
            Paragraph prg = section.AddParagraph();
            foreach (string stroka in stroki)
            {
                if (stroka == null)
                {
                    throw new Exception("There is no data somewhere");
                }
                prg.AddText(stroka + "\n");
            }
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(folder);
        }
    }
}
