using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Citas_Medicas.Modelo
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Doctor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Id_Especialidades { get; set; }
        public ICollection<Citas> Citas { get; set; }

    }
}
