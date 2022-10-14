using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop_bibl
{
    public partial class PdfFirstComponent : Component
    {
        public PdfFirstComponent()
        {
            InitializeComponent();
        }

        public PdfFirstComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
