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
//using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
//using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using Page = ceTe.DynamicPDF.Page;
using MigraDoc.RtfRendering;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Shapes;
namespace Kop_bibl.NonVisualComponent
{
    public partial class LinearDiagramPdfComponent : Component
    {
        public LinearDiagramPdfComponent()
        {
            InitializeComponent();
        }

        public LinearDiagramPdfComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void SaveDiagram(string title, string folder, string name)
        {
            var document = new Document();
            Section section = document.AddSection();
            var chart = new Chart(ChartType.Line);
            var series = chart.SeriesCollection.AddSeries();
            series.Name = "Hello";
            series.Add(10, 20);
            var xseries = chart.XValues.AddXSeries();
            xseries.Add(new string[] { "1", "2", "3" });
            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);
            chart.TopArea.AddParagraph(title);
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;
            chart.RightArea.AddLegend();
            document.LastSection.Add(chart);
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
