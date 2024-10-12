using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTbTb.Context;
using PruebaTecnicaTbTb.Interface;
using PruebaTecnicaTbTb.Models;

namespace PruebaTecnicaTbTb.Services
{
    // Servicio que maneja la lógica de negocio relacionada con los médicos.
    // Implementa IMedicoService y se encarga de las operaciones CRUD para los médicos.
    public class MedicoService : IMedicoService
    {
        private readonly DbContextApp _context;

        // Constructor del servicio MedicoService.
        // Recibe el contexto de la base de datos inyectado por el contenedor de dependencias.
        public MedicoService(DbContextApp dbContextApp)
        {
            _context = dbContextApp;
        }

        // Obtiene una lista de todos los médicos.
        public async Task<List<Medico>> GetMedicos()
        {
            return await _context.medico.ToListAsync();
        }

        // Obtiene un médico por su ID.
        // Retorna un objeto Medico vacío si no se encuentra.
        public async Task<Medico> GetMedicoById(int id)
        {
            return await _context.medico.FirstOrDefaultAsync(x => x.MedicoID == id) ?? new Medico();
        }

        // Actualiza la información de un médico existente.
        // Retorna null si el médico no se encuentra.
        // Puede lanzar DbUpdateConcurrencyException si hay problemas de concurrencia.
        public async Task<Medico> UpdateMedicoAsync(int id, MedicoDto medicoDto)
        {
            var medico = await _context.medico.FindAsync(id);
            if (medico == null)
            {
                return null;
            }

            // Actualiza solo los campos proporcionados en el DTO
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

        // Verifica si existe un médico con el ID especificado.
        private bool MedicoExists(int id)
        {
            return _context.medico.Any(e => e.MedicoID == id);
        }

        // Crea un nuevo médico en la base de datos.
        public async Task<Medico> CreateMedicoAsync(MedicoDto medicoDto)
        {
            var medico = new Medico
            {
                Nombre = medicoDto.Nombre,
                Especialidad = medicoDto.Especialidad,
                // Configura la fecha ya que C# no la recibe en el formato original del API
                FechaIngreso = medicoDto.FechaIngreso ?? DateTime.UtcNow
            };
            _context.medico.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        // Elimina un médico de la base de datos.
        // Retorna true si el médico fue eliminado, false si no se encontró.
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