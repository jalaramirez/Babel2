using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Class1
    {

    }

    public class Cliente 
    {
        public List<RelCliPln> REL_CLIENTE_PLAN { get; set; }
        public int IDCLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APPATERNO { get; set; }
        public string APMATERNO { get; set; }
        public bool BORRADO { get; set; }
        public string FECHAMOD { get; set; }
    }

    public class Plan 
    {
        public List<RelCliPln> REL_CLIENTE_PLAN { get; set; }
        public List<RelPlcCbr> REL_PLAN_COBER { get; set; }
        public int IDPLAN { get; set; }
        public string DESCRIPCION { get; set; }
        public string FECHAMOD { get; set; }
    }

    public class Cobertura 
    {
        public List<RelPlcCbr> REL_PLAN_COBER { get; set; }
        public int IDCOBERTURA { get; set; }
        public string DESCRIPCION { get; set; }
        public string FECHAMOD { get; set; }
    }

    public class RelCliPln 
    {
        public Cliente CLIENTES { get; set; }
        public Plan PLANES { get; set; }
        public int IDCP { get; set; }
        public int IDCLIENTE { get; set; }
        public int IDPLAN { get; set; }

    }

    public class RelPlcCbr
    {
        public Cobertura COBERTURA { get; set; }
        public Plan PLANES { get; set; }
        public int IDpc { get; set; }
        public int IDPLAN { get; set; }
        public int IDCOBER { get; set; }

    }
}