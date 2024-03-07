namespace Projeto_Final_de_Curso4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_adopcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_adopcao()
        {
            tb_devolucao_de_animal = new HashSet<tb_devolucao_de_animal>();
        }

        [Key]
        public int id_adopcao { get; set; }

        [StringLength(128)]
        public string id_cliente { get; set; }

        public int? id_funcionario { get; set; }

        public int id_animal { get; set; }

        public int id_estado_da_adopcao { get; set; }

        [StringLength(50)]
        public string data_de_entrega { get; set; }

        [StringLength(255)]
        public string motivo_da_adopcao { get; set; }

        [StringLength(50)]
        public string data_de_solicitacao_do_animal { get; set; }

        public virtual tb_animal tb_animal { get; set; }

        public virtual tb_estado_da_adopcao tb_estado_da_adopcao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_devolucao_de_animal> tb_devolucao_de_animal { get; set; }
    }
}
