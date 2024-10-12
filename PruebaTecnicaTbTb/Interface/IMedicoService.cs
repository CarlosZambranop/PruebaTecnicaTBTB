using PruebaTecnicaTbTb.Models;

namespace PruebaTecnicaTbTb.Interface
{
    public interface IMedicoService
    {
        Task<Medico> GetMedicoById(int id);
        Task<List<Medico>> GetMedicos();
        Task<Medico> CreateMedicoAsync(MedicoDto medico);
        Task<Medico> UpdateMedicoAsync(int id, MedicoDto medicoDto);
        Task<bool> DeleteMedicoAsync(int id);
    }
}
