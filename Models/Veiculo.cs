using System;
using System.Collections.Generic;

namespace OficinaBertelli.Models
{
    public partial class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int CodCliente { get; set; }
        public int CodMontadora { get; set; }
        public int CodModelo { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public int CodVeiculo { get; set; }
    }
}
