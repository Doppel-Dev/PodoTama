namespace PodoTama.UI.Services;
using PodoTama.Application.DTOs;
using System.Net.Http.Json;

public class PacienteService
{
    private readonly HttpClient _http;

    public PacienteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<PacienteDTO>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<PacienteDTO>>("api/Paciente/")
               ?? new List<PacienteDTO>();
    }

    public async Task<PacienteDTO?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<PacienteDTO>($"api/Paciente/{id}");
    }
    public async Task<bool> UpdateAsync(PacienteDTO paciente)
    {
        var response = await _http.PutAsJsonAsync($"api/Paciente/{paciente.IdPaciente}", paciente);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> CreateAsync(PacienteDTO paciente)
    {
        var response = await _http.PostAsJsonAsync("api/Paciente/", paciente);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Paciente/{id}");
        return response.IsSuccessStatusCode;
    }

}
