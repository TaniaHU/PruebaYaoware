using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BOL.Modelos;

namespace Test.DAL
{
    public partial class BaseDatosContext : DbContext
    {
        #region Tablas
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Estatus> Estatus { get; set; }


        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigApp app = new ConfigApp();
            optionsBuilder.UseSqlServer(app.CadenaServidor);
        }
    }
}
