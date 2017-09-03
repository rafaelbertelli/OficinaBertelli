using System;
using System.Collections.Generic;

namespace OficinaBertelli.Models
{
    public partial class Clientes
    {
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string Rg { get; set; }
        public string Cgc { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string TelRes { get; set; }
        public string Celular { get; set; }
        public string TelCom { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Status { get; set; }
    }
}
