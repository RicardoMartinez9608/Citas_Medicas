using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Citas_Medicas.Modelo
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Paciente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Domicilio { get; set; }

    }
}
