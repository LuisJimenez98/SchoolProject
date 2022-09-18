using Api.Gateway.Application.Behaviors.Commands.Qualification;
using Api.Gateway.Application.Behaviors.Queries;
using Api.Gateway.Application.DTOs.Qualification;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Application.Wrappers
{
    public interface IQualificationProxy
    {
        Task<Response<int>> CreateAsync(CreateQualificationCommand command);
        Task<Response<int>> UpdateAsync(UpdateQualificationCommand command);
        Task<Response<int>> DeleteAsync(DeleteQualificationCommand command);
        Task<PagedResponse<List<CalificacionDto>>> GetAllAsync(GetAllQuery command);
        Task<Response<CalificacionDto>> GetByIdAsync(GetByIdQuery command);
    }

    public class QualificationProxy : IQualificationProxy
    {
        private readonly ApiUrl _apiUrl;
        private readonly HttpClient _httpClient;


        public QualificationProxy(HttpClient httpClient, IOptions<ApiUrl> apiUrl)
        {
            _httpClient = httpClient;
            _apiUrl = apiUrl.Value;
        }


        public async Task<Response<int>> CreateAsync(CreateQualificationCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrl.QualificationUrl}api/v1/Qualification", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> DeleteAsync(DeleteQualificationCommand command)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrl.QualificationUrl}api/v1/Qualification/{command.CalificacionId}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<PagedResponse<List<CalificacionDto>>> GetAllAsync(GetAllQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.QualificationUrl}api/v1/Qualification");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<PagedResponse<List<CalificacionDto>>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<CalificacionDto>> GetByIdAsync(GetByIdQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.QualificationUrl}api/v1/Qualification/{command.Id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<CalificacionDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> UpdateAsync(UpdateQualificationCommand command)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(command),
               Encoding.UTF8,
               "application/json"
           );

            var request = await _httpClient.PutAsync($"{_apiUrl.QualificationUrl}api/v1/Qualification/{command.CalificacionId}", content);
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
