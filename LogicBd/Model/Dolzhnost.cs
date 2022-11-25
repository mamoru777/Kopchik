using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogicBd.Model
{
    public class Dolzhnost
    {
        public int Id { get; set; }
        [Required]
        public string Dol { get; set; }
    }
}
