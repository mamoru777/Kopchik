using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicBd.BindingModel
{
    public class SotrudnikBindingModel
    {
        public int? Id { get; set; }
        public string FIO { get; set; }
        public string Autobiography { get; set; }
        public string Dol { get; set; }
        public DateTime? dateupkval { get; set; }
    }
}
