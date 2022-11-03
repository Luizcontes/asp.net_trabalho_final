using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp.net_trabalho_final.Models
{
    public partial class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public long Nif { get; set; }
        public float Saldo { get; set; }
        public DateTime Data { get; set; }
    }
}
