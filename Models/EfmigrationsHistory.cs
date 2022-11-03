using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace asp.net_trabalho_final.Models
{
    public partial class EfmigrationsHistory
    {
        [Key]
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
