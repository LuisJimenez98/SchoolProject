using Api.Gateway.Model.School.Commands;
using Api.Gateway.Model.School.DTOs;
using Api.Gateway.Model.School.Queries;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxy
{
    public interface ISchoolProxy
    {
        Task<Response<int>> CreateAsync(CreateSchoolCommand command);
        Task<Response<int>> UdateAsync(UpdateSchoolCommand command);
        Task<Response<int>> DeleteAsync(DeleteSchoolCommand command);
        Task<PagedResponse<List<ColegioDto>>> GetAllAsync(GetAllQuery command);
        Task<Response<ColegioDto>> GetByIdAsync(GetByIdQuery command);
    }

    public class SchoolProxy: ISchoolProxy
    {
        private readonly ApiUrl _apiUrl;
        private readonly HttpClient _httpClient;


        public SchoolProxy(HttpClient httpClient, IOptions<ApiUrl> apiUrl)
        {
            _httpClient = httpClient;
            _apiUrl = apiUrl.Value;
        }


        public async Task<Response<int>> CreateAsync(CreateSchoolCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrl.SchoolUrl}api/v1/school", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> DeleteAsync(DeleteSchoolCommand command)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrl.SchoolUrl}api/v1/school/{command.ColegioId}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<PagedResponse<List<ColegioDto>>> GetAllAsync(GetAllQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.SchoolUrl}api/v1/school");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<PagedResponse<List<ColegioDto>>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<ColegioDto>> GetByIdAsync(GetByIdQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.SchoolUrl}api/v1/school/{command.ColegioId}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<ColegioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> UdateAsync(UpdateSchoolCommand command)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(command),
               Encoding.UTF8,
               "application/json"
           );

            var request = await _httpClient.PutAsync($"{_apiUrl.SchoolUrl}api/v1/school/{command.ColegioId}", content);
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
