using PodoTama.Application.DTOs;
using System.Net.Http.Json;

namespace PodoTama.UI.Services
{
    public class ProfesionalService
    {

        private readonly HttpClient _http;

        public ProfesionalService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProfesionalDTO>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<ProfesionalDTO>>("api/Profesional/")
                   ?? new List<ProfesionalDTO>();
        }

        public async Task<ProfesionalDTO?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<ProfesionalDTO>($"api/Profesional/{id}");
        }
        public async Task<bool> UpdateAsync(ProfesionalDTO profesional)
        {
            var response = await _http.PutAsJsonAsync($"api/Profesional/{profesional.IdProfesional}", profesional);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateAsync(ProfesionalDTO profesional)
        {
            var response = await _http.PostAsJsonAsync("api/Profesional/", profesional);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Profesional/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
