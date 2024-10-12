using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaTbTb.Interface;
using PruebaTecnicaTbTb.Models;

namespace PruebaTecnicaTbTb.Controllers
{
    // Controlador para manejar las operaciones CRUD de médicos a través de la API
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        // Constructor que recibe el servicio de médicos por inyección de dependencias
        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // GET: api/Medico
        // Obtiene todos los médicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            var result = await _medicoService.GetMedicos();
            return Ok(result);
        }

        // POST: api/Medico
        // Crea un nuevo médico
        [HttpPost]
        public async Task<IActionResult> CreateMedico(MedicoDto medicoDto)
        {
            var createdMedico = await _medicoService.CreateMedicoAsync(medicoDto);
            return CreatedAtAction(nameof(GetMedico), new { id = createdMedico.MedicoID }, createdMedico);
        }

        // GET: api/Medico/5
        // Obtiene un médico específico por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetMedico(int id)
        {
            var medic = await _medicoService.GetMedicoById(id);
            if (medic == null)
            {
                return NotFound();
            }
            return medic;
        }

        // PUT: api/Medico/5
        // Actualiza un médico existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedico(int id, MedicoDto medicoDto)
        {
            var updatedMedico = await _medicoService.UpdateMedicoAsync(id, medicoDto);
            if (updatedMedico == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Medico/5
        // Elimina un médico específico
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            var result = await _medicoService.DeleteMedicoAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}