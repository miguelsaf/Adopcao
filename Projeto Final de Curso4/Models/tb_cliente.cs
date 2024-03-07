namespace Projeto_Final_de_Curso4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_cliente
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        public int id_genero { get; set; }

        [StringLength(50)]
        public string bairro { get; set; }

        [StringLength(50)]
        public string rua_casa { get; set; }

        public int contacto { get; set; }

        [StringLength(50)]
        public string n_BI { get; set; }

        public int id_municipio { get; set; }

        [StringLength(100)]
        public string ocupacao { get; set; }

        [StringLength(50)]
        public string data_de_nascimento { get; set; }

        public virtual tb_genero tb_genero { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual tb_municipio tb_municipio { get; set; }
    }
}
