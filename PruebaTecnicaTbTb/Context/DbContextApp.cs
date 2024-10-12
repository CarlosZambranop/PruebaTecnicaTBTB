using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTbTb.Models;

namespace PruebaTecnicaTbTb.Context
{
    public class DbContextApp:DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {
        }

        public DbSet<Medico> medico { get; set; }
        public DbSet<Paciente> paciente { get; set; }
        public DbSet<CitaMedica> citaMedica { get; set; }
    }
}
