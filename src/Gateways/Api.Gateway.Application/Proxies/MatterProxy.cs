using Api.Gateway.Application.Behaviors.Commands.Matter;
using Api.Gateway.Application.Behaviors.Queries;
using Api.Gateway.Application.DTOs.Matter;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Application.Wrappers
{
    public interface IMatterProxy
    {
        Task<Response<int>> CreateAsync(CreateMatterCommand command);
        Task<Response<int>> UdateAsync(UpdateMatterCommand command);
        Task<Response<int>> DeleteAsync(DeleteMatterCommand command);
        Task<PagedResponse<List<MateriaDto>>> GetAllAsync(GetAllQuery command);
        Task<Response<MateriaDto>> GetByIdAsync(GetByIdQuery command);
    }

    public class MatterProxy : IMatterProxy
    {
        private readonly ApiUrl _apiUrl;
        private readonly HttpClient _httpClient;


        public MatterProxy(HttpClient httpClient, IOptions<ApiUrl> apiUrl)
        {
            _httpClient = httpClient;
            _apiUrl = apiUrl.Value;
        }


        public async Task<Response<int>> CreateAsync(CreateMatterCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrl.MatterUrl}api/v1/matter", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> DeleteAsync(DeleteMatterCommand command)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrl.MatterUrl}api/v1/matter/{command.MateriaId}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<PagedResponse<List<MateriaDto>>> GetAllAsync(GetAllQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.MatterUrl}api/v1/matter");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<PagedResponse<List<MateriaDto>>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<MateriaDto>> GetByIdAsync(GetByIdQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.MatterUrl}api/v1/matter/{command.Id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<MateriaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> UdateAsync(UpdateMatterCommand command)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(command),
               Encoding.UTF8,
               "application/json"
           );

            var request = await _httpClient.PutAsync($"{_apiUrl.MatterUrl}api/v1/matter/{command.MateriaId}", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }
    }
}
