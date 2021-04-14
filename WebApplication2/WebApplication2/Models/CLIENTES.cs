namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTES()
        {
            REL_CLIENTE_PLAN = new HashSet<REL_CLIENTE_PLAN>();
        }

        [Key]
        public int IDCLIENTE { get; set; }

        [StringLength(50)]
        public string NOMBRE { get; set; }

        [StringLength(50)]
        public string APPATERNO { get; set; }

        [StringLength(50)]
        public string APMATERNO { get; set; }

        public bool? BORRADO { get; set; }

        public DateTime? FECHAMOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REL_CLIENTE_PLAN> REL_CLIENTE_PLAN { get; set; }
    }
}
