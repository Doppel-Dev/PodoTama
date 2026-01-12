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
        return await _http.GetFromJsonAsync<List<PacienteDTO>>("api/Pacientes/")
               ?? new List<PacienteDTO>();
    }

    public async Task<PacienteDTO?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<PacienteDTO>($"api/Pacientes/{id}");
    }
    public async Task<bool> UpdateAsync(PacienteDTO paciente)
    {
        var response = await _http.PutAsJsonAsync($"api/Pacientes/{paciente.IdPaciente}", paciente);
        return response.IsSuccessStatusCode;
    }

}
