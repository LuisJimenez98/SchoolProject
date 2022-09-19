using Api.Gateway.Application.Behaviors.Commands.User;
using Api.Gateway.Application.Behaviors.Queries;
using Api.Gateway.Application.DTOs.User;
using Api.Gateway.Application.Wrappers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Application.Proxies
{

    public interface IUserProxy
    {
        Task<Response<int>> CreateAsync(CreateUserCommand command);
        Task<Response<int>> UpdateAsync(UpdateUserCommand command);
        Task<Response<int>> DeleteAsync(DeleteUserCommand command);
        Task<PagedResponse<List<UsuarioDto>>> GetAllAsync(GetAllQuery command);
        Task<Response<UsuarioDto>> GetByIdAsync(GetByIdQuery command);
    }


    public class UserProxy : IUserProxy
    {
        private readonly ApiUrl _apiUrl;
        private readonly HttpClient _httpClient;


        public UserProxy(HttpClient httpClient, IOptions<ApiUrl> apiUrl)
        {
            _httpClient = httpClient;
            _apiUrl = apiUrl.Value;
        }


        public async Task<Response<int>> CreateAsync(CreateUserCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrl.UserUrl}api/v1/user", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> DeleteAsync(DeleteUserCommand command)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrl.UserUrl}api/v1/user/{command.UsuarioId}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<int>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<PagedResponse<List<UsuarioDto>>> GetAllAsync(GetAllQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.UserUrl}api/v1/user");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<PagedResponse<List<UsuarioDto>>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<UsuarioDto>> GetByIdAsync(GetByIdQuery command)
        {
            var request = await _httpClient.GetAsync($"{_apiUrl.UserUrl}api/v1/user/{command.Id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Response<UsuarioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }

        public async Task<Response<int>> UpdateAsync(UpdateUserCommand command)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(command),
               Encoding.UTF8,
               "application/json"
           );

            var request = await _httpClient.PutAsync($"{_apiUrl.UserUrl}api/v1/user/{command.UsuarioId}", content);
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
