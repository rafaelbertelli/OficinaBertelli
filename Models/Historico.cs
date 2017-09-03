using System;
using System.Collections.Generic;

namespace OficinaBertelli.Models
{
    public partial class Historico
    {
        public int Sequencia { get; set; }
        public int OrdemServico { get; set; }
        public string Placa { get; set; }
        public int CodigoCliente { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string ValorTotal { get; set; }
        public string Tecnico { get; set; }
        public string Obs { get; set; }
        public int CodigoVeiculo { get; set; }
    }
}
