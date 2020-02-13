using System;
using System.Collections.Generic;
using System.Text;
using Cajas_SqlServer_Login.Areas.caja.Models;
using Cajas_SqlServer_Login.Areas.carpeta.Models;
using Cajas_SqlServer_Login.Areas.tipo_caja.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cajas_SqlServer_Login.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //propiedades para exponer el modelo
        public virtual DbSet<t_tipo_caja> ttipocaja { get; set; }
        public virtual DbSet<t_caja> tcaja { get; set; }
        public virtual DbSet<t_carpeta> tcarpeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //la cadena es la misma que DefaultConnection que se encuentra en appsettings.json pero al final se agrega un ';'
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JI5A1PF;Initial Catalog=dbcajaslogin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }
    }
}
