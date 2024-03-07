namespace Projeto_Final_de_Curso4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_animal()
        {
            tb_adopcao = new HashSet<tb_adopcao>();
        }

        [Key]
        public int id_animal { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        public int id_cor { get; set; }

        public int id_genero { get; set; }

        public int id_tipo_de_animal { get; set; }

        public int id_disponibilidade_do_animal { get; set; }

        [StringLength(50)]
        public string idade { get; set; }

        [StringLength(50)]
        public string raca { get; set; }

        [StringLength(50)]
        public string peso { get; set; }

        [StringLength(255)]
        public string foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_adopcao> tb_adopcao { get; set; }

        public virtual tb_cor tb_cor { get; set; }

        public virtual tb_disponibilidade_do_animal tb_disponibilidade_do_animal { get; set; }

        public virtual tb_genero tb_genero { get; set; }

        public virtual tb_tipo_de_animal tb_tipo_de_animal { get; set; }
    }
}
