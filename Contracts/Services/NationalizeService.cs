using Core.DTO;
using Core.Interfaces.Services;
using Newtonsoft.Json;


namespace Business.Services
{
    public class NationalizeService : INationalizeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NationalizeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<NationalizeResponseDTO> GetNationalitiesAsync(string name)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"https://api.nationalize.io/?name={name}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NationalizeResponseDTO>(content);
        }
    }
}
