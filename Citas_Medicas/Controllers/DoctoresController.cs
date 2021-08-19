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
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Doctores")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private readonly CitasContexto _context;
        public DoctoresController(CitasContexto context)
        {
            _context = context;
        }
        //Metodo para agregar Doctores
        [HttpPost]
        public async Task<IActionResult> Crear_Doctores([FromBody] Doctor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Doctor.Add(doctor).State = EntityState.Added;
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
        public async Task<IActionResult> Editar_Doctores([FromBody] Doctor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Doctor.Add(doctor).State = EntityState.Modified;
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
        public async Task<IActionResult> ObtenerDoctorEspecifico(int id_doctor)
        {
            try
            {
                Doctor doctor = _context.Doctor.AsNoTracking().Single(g => g.Id_Doctor == id_doctor);
                return Ok(doctor);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }

        }
    }
}
