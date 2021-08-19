using Citas_Medicas.Modelo;
using Citas_Medicas.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas_Medicas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Pacientes")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly CitasContexto _context;
        public PacientesController(CitasContexto context)
        {
            _context = context;
        }
        //Metodo para agregar pacientes
        [HttpPost]
        public async Task<IActionResult> Crear_Pacientes([FromBody] Paciente paciente)
        {
            try
            {
                    if (ModelState.IsValid)
                    {
                        _context.Paciente.Add(paciente).State = EntityState.Added;
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
        //Metodo para editar pacientes
        [HttpPost]
        public async Task<IActionResult> Editar_Pacientes([FromBody] Paciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Paciente.Add(paciente).State = EntityState.Modified;
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
        public async Task<IActionResult> ObtenerPacienteEspecifico (int id_paciente)
        {
            try
            {
                Paciente paciente = _context.Paciente.AsNoTracking().Single(g => g.Id_Paciente == id_paciente);
                return Ok(paciente);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }
          
        }
    }
}
