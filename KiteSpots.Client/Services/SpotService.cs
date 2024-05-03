using System.Text.Json;
using Common.DTO;
using Common.Interface;

namespace KiteSpots.Client.Services;

public class SpotService : ISpotService<SpotDTO>
{
    private readonly HttpClient _httpClient;

    public SpotService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("KiteSpotsApi");
    }

    public async Task<IEnumerable<SpotDTO>> GetAllSpots()
    {
        var response = await _httpClient.GetAsync("/spots");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<SpotDTO>();
        }

        var result = await response.Content.ReadFromJsonAsync<IEnumerable<SpotDTO>>();
        return result ?? Enumerable.Empty<SpotDTO>();
    }

    public async Task<SpotDTO> GetOneSpot(int id)
    {
        var response = await _httpClient.GetAsync($"/spots/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadFromJsonAsync<SpotDTO>();

        return result;
    }

    public async Task<SpotDTO> CreateSpot(SpotDTO newSpot)
    {
        var response = await _httpClient.PostAsJsonAsync("/spots", newSpot);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadFromJsonAsync<SpotDTO>();

        return result;
    }

    public async Task<SpotDTO> UpdateSpot(SpotDTO updatedSpot)
    {
        var response = await _httpClient.PutAsJsonAsync($"/spots/{updatedSpot.Id}", updatedSpot);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadFromJsonAsync<SpotDTO>();

        return result;
    }

    public async Task<bool> DeleteSpot(int id)
    {
        var response = await _httpClient.DeleteAsync($"/spots/{id}");

        return response.IsSuccessStatusCode;
    }
}