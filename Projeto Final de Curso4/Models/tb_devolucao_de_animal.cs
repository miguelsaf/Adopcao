namespace Projeto_Final_de_Curso4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_devolucao_de_animal
    {
        [Key]
        public int id_devolucao_de_animal { get; set; }

        public int id_adopcao { get; set; }

        [StringLength(200)]
        public string motivo_da_devolucao { get; set; }

        [StringLength(50)]
        public string data_da_devolucao { get; set; }

        public virtual tb_adopcao tb_adopcao { get; set; }
    }
}
