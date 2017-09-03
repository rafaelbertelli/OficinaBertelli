using System;
using System.Collections.Generic;

namespace OficinaBertelli.Models
{
    public partial class HistItem
    {
        public int IdHitem { get; set; }
        public int Sequencia { get; set; }
        public int Item { get; set; }
        public string Tipo { get; set; }
        public string Historico { get; set; }
        public int? Quantidade { get; set; }
        public string Valor { get; set; }
    }
}
