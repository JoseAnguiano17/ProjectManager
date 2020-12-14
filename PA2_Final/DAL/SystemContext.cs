using PA2_Final.Models;
using PA2_Final.Models.PatronEstado;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PA2_Final.DAL
{
    public class SystemContext : DbContext
    {
        public SystemContext() : base("SystemContext")
        {

        }

        public System.Data.Entity.DbSet<PA2_Final.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<PA2_Final.Models.Proyecto> Proyectoes { get; set; }

        public System.Data.Entity.DbSet<PA2_Final.Models.Sugerencia> Sugerencias { get; set; }

        public System.Data.Entity.DbSet<PA2_Final.Models.Error> Errors { get; set; }

        public System.Data.Entity.DbSet<PA2_Final.Models.Actualizacion> Actualizacions { get; set; }
    }
}