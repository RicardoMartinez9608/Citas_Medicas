using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Citas_Medicas.Modelo
{
    public class Especialidades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Especialidades { get; set; }
        public string Especialidad { get; set; }
        public ICollection<Doctor> Doctores { get; set; }
        public ICollection<Citas> Especialidades_Citas { get; set; }

    }
}
