using Citas_Medicas.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas_Medicas.Persistencia
{
    public class CitasContexto : DbContext
    {
        public CitasContexto(DbContextOptions<CitasContexto> options) : base(options)
        {
        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }


    }
}
