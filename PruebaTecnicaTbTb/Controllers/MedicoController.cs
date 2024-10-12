using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTbTb.Context;
using PruebaTecnicaTbTb.Interface;
using PruebaTecnicaTbTb.Models;

namespace PruebaTecnicaTbTb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }
        // GET: api/Medico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            var result = await _medicoService.GetMedicos();
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedico(MedicoDto medicoDto)
        {
            var createdMedico = await _medicoService.CreateMedicoAsync(medicoDto);
            return CreatedAtAction(nameof(GetMedico), new { id = createdMedico.MedicoID }, createdMedico);
        }
        // GET: api/Medico/5
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
