using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTbTb.Context;
using PruebaTecnicaTbTb.Interface;
using PruebaTecnicaTbTb.Models;

namespace PruebaTecnicaTbTb.Services
{
    //hago el servicio para hacer toda la logica e evitar llamar el contexto de la base de datos en los controladores
    public class MedicoService : IMedicoService
    {
        private readonly DbContextApp _context;
        public MedicoService(DbContextApp dbContextApp)
        {
            _context = dbContextApp;
        }
        public async Task<List<Medico>> GetMedicos()
        {
            return _context.medico.ToList();
        }
        public async Task<Medico> GetMedicoById(int id)
        {
            var result = new Medico();
            if (id != null)
            {
                result = _context.medico.Where(x => x.MedicoID == id).FirstOrDefault();
            }
            return result;
        }
        public async Task<Medico> UpdateMedicoAsync(int id, MedicoDto medicoDto)
        {
            var medico = await _context.medico.FindAsync(id);

            if (medico == null)
            {
                return null;
            }

            // Actualizamos solo los campos que se proporcionan en el DTO
            if (!string.IsNullOrWhiteSpace(medicoDto.Nombre))
            {
                medico.Nombre = medicoDto.Nombre;
            }

            if (!string.IsNullOrWhiteSpace(medicoDto.Especialidad))
            {
                medico.Especialidad = medicoDto.Especialidad;
            }

            if (medicoDto.FechaIngreso.HasValue)
            {
                medico.FechaIngreso = medicoDto.FechaIngreso.Value;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return medico;
        }

        private bool MedicoExists(int id)
        {
            return _context.medico.Any(e => e.MedicoID == id);
        }
        public async Task<Medico> CreateMedicoAsync(MedicoDto medicoDto)
        {
            var medico = new Medico
            {
                Nombre = medicoDto.Nombre,
                Especialidad = medicoDto.Especialidad,
                //Configuro la fecha ya que c# no la recibe en el formato original el API
                FechaIngreso = medicoDto.FechaIngreso ?? DateTime.UtcNow
            };

            _context.medico.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }
        public async Task<bool> DeleteMedicoAsync(int id)
        {
            var medico = await _context.medico.FindAsync(id);
            if (medico == null)
            {
                return false;
            }

            _context.medico.Remove(medico);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
