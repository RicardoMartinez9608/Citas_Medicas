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
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Diagnostico")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly CitasContexto _context;
        public DiagnosticoController(CitasContexto context)
        {
            _context = context;
        }

        //Metodo para agregar Citas
        [HttpPost]
        public async Task<IActionResult> Crear_Diagnostico([FromBody] Diagnostico diagnostico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Diagnosticos.Add(diagnostico).State = EntityState.Added;
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

        //Metodo para editar citas
        [HttpPost]
        public async Task<IActionResult> Editar_Diagnostico([FromBody] Diagnostico diagnostico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Diagnosticos.Add(diagnostico).State = EntityState.Modified;
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
        public async Task<IActionResult> ObtenerDiagnosticoEspecifico(int id_diagnostico)
        {
            try
            {
                Diagnostico diagnostico = _context.Diagnosticos
                    .Include(a=>a.Paciente)
                    .Include(a=>a.Doctor)
                    .AsNoTracking().Single(g => g.Id_Diagnostico == id_diagnostico);
                return Ok(diagnostico);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }

        }
    }
}
