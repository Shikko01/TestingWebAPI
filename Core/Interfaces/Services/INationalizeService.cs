using Core.DTO;

namespace Core.Interfaces.Services
{
    public interface INationalizeService
    {
        Task<NationalizeResponseDTO> GetNationalitiesAsync(string name);
    }
}
