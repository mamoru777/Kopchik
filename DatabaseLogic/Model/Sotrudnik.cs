using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLogic.Model
{
    public class Sotrudnik
    {
        
        public int Id { get; set; }
        
        public string FIO { get; set; }
        
        public string Autobiography { get; set; }
        
        public string Dol { get; set; }
       
        public string dateupkval { get; set; }
        public override string ToString() => $"{Id} - {FIO} {Dol} ({dateupkval})";

    }
}
