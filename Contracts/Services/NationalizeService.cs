using Core.DTO;
using Core.Interfaces.Services;
using Newtonsoft.Json;

namespace Business.Services
{
    public class NationalizeService : INationalizeService
    {
        private readonly HttpClient _httpClient;

        public NationalizeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NationalizeResponseDTO> GetNationalitiesAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://api.nationalize.io/?name={name}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NationalizeResponseDTO>(content);
        }
    }
}
