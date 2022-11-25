using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LogicBd.ViewModel
{
    public class DolzhnostViewModel
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Должность")]
        public string Dol { get; set; }
    }
}
