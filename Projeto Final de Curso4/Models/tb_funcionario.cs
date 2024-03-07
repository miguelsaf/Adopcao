namespace Projeto_Final_de_Curso4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_funcionario
    {
        [Key]
        public int id_funcionario { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public int id_genero { get; set; }

        [StringLength(50)]
        public string bairro { get; set; }

        [StringLength(50)]
        public string rua_casa { get; set; }

        public int contacto { get; set; }

        [StringLength(50)]
        public string n_BI { get; set; }

        public int id_municipio { get; set; }

        [StringLength(128)]
        public string id_usuario { get; set; }

        public virtual tb_genero tb_genero { get; set; }

        public virtual tb_municipio tb_municipio { get; set; }
    }
}
