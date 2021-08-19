using Citas_Medicas.Modelo;
using Citas_Medicas.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas_Medicas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Especialidades")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly CitasContexto _context;
        public EspecialidadesController(CitasContexto context)
        {
            _context = context;
        }
        //Metodo para agregar Especialidades
        [HttpPost]
        public async Task<IActionResult> Crear_Especialidad([FromBody] Especialidades especialidades)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Especialidades.Add(especialidades).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    return Ok("Valores Almacenados exitosamente");
                }
                else
                {
                    return BadRequest(ModelState.ValidationState.ToString());
                }
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }
        }
        //Metodo para editar especialidad
        [HttpPost]
        public async Task<IActionResult> Editar_Pacientes([FromBody] Especialidades especialidades)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Especialidades.Add(especialidades).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Valores Editados exitosamente");
                }
                else
                {
                    return BadRequest(ModelState.ValidationState.ToString());
                }
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerEspecialidadEspecifico(int id_especialidad)
        {
            try
            {
                Especialidades especialidades = _context.Especialidades.AsNoTracking()
                    .Single(g => g.Id_Especialidades == id_especialidad);
                return Ok(especialidades);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }

        }
    }
}
