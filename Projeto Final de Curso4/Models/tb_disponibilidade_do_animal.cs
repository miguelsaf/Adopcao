namespace Projeto_Final_de_Curso4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_disponibilidade_do_animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_disponibilidade_do_animal()
        {
            tb_animal = new HashSet<tb_animal>();
        }

        [Key]
        public int id_disponibilidade_do_animal { get; set; }

        [StringLength(50)]
        public string disponibilidade_do_animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_animal> tb_animal { get; set; }
    }
}
