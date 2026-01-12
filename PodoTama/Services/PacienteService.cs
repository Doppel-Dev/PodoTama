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
}
