using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citas_Medicas.Modelo
{
    public class Citas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Cita { get; set; }
        public int Id_Doctor { get; set; }
        public Doctor Doctor { get; set; }
        public int Id_Paciente { get; set; }
        public Paciente Paciente { get; set; }
        public int Id_Especialidades { get; set; }
        public Especialidades Especialidades { get; set; }
        public DateTime Fecha_Cita { get; set; }

    }
}
