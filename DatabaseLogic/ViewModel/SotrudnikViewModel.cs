using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DatabaseLogic.ViewModel
{
    public class SotrudnikViewModel
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("ФИО")]
        public string FIO { get; set; }
        [DisplayName("Автобиография")]
        public string Autobiography { get; set; }
        [DisplayName("Должность")]
        public string Dol { get; set; }
        [DisplayName("Дата повышения квалификации")]
        public string dateupkval { get; set; }
    }
}
