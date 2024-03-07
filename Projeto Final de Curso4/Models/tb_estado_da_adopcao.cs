namespace Projeto_Final_de_Curso4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_estado_da_adopcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_estado_da_adopcao()
        {
            tb_adopcao = new HashSet<tb_adopcao>();
        }

        [Key]
        public int id_estado_da_adopcao { get; set; }

        [StringLength(50)]
        public string estado_da_adopcao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_adopcao> tb_adopcao { get; set; }
    }
}
