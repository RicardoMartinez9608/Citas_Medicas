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
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Citas")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly CitasContexto _context;
        public CitasController(CitasContexto context)
        {
            _context = context;
        }

        //Metodo para agregar Citas
        [HttpPost]
        public async Task<IActionResult> Crear_Cita([FromBody] Citas cita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Citas.Add(cita).State = EntityState.Added;
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
        public async Task<IActionResult> Editar_Citas([FromBody] Citas citas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Citas.Add(citas).State = EntityState.Modified;
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
        public async Task<IActionResult> ObtenerCitaEspecifico(int id_cita)
        {
            try
            {
                Citas cita = _context.Citas.AsNoTracking().Single(g => g.Id_Cita == id_cita);
                return Ok(cita);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }

        }
    }
}
