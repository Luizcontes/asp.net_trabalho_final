using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_trabalho_final.Models
{
    public partial class Movimento
    {
        [Key]
        public DateTime Data { get; set; }
        public float Valor { get; set; }

        [ForeignKey("Cliente")]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        
    }
}
