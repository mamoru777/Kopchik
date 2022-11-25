using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogicBd.Model
{
    public class Sotrudnik
    {
        
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Autobiography { get; set; }
        [Required]
        public string Dol { get; set; }
        [Required]
        public DateTime? dateupkval { get; set; }

    }
}
