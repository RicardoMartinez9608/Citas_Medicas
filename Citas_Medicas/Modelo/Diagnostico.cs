using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Citas_Medicas.Modelo
{
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Diagnostico { get; set; }
        public int Id_Paciente { get; set; }
        public Paciente Paciente { get; set; }
        public int Id_Doctor { get; set; }
        public Doctor Doctor { get; set; }
        public string Diagnostico_Paciente { get; set; }

    }
}
