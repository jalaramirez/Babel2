namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REL_CLIENTE_PLAN
    {
        [Key]
        public int IDCP { get; set; }

        public int IDCLIENTE { get; set; }

        public int IDPLAN { get; set; }

        public virtual CLIENTES CLIENTES { get; set; }

        public virtual PLANES PLANES { get; set; }
    }
}
