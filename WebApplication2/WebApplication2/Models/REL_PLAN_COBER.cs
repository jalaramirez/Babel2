namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REL_PLAN_COBER
    {
        [Key]
        public int IDpc { get; set; }

        public int IDPLAN { get; set; }

        public int IDCOBER { get; set; }

        public virtual COBERTURA COBERTURA { get; set; }

        public virtual PLANES PLANES { get; set; }
    }
}
