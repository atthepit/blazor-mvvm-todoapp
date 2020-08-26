using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoMvvmApp.Shared;

namespace TodoMvvmApp.Client.Services
{
    public interface ITodosService
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task AddAsync(Todo todo);
        Task DeleteAsync(Todo todo);
        Task UpdateAsync(Todo todo);
    }

    public class TodosService : ITodosService
    {
        private readonly HttpClient _http;

        public TodosService(HttpClient http)
        {
            _http = http;
        }

        public async Task AddAsync(Todo todo)
        {
            await _http.PostAsJsonAsync<Todo>("api/Todos", todo);
        }

        public async Task DeleteAsync(Todo todo)
        {
            await _http.DeleteAsync($"api/Todos/{todo.Id}");
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Todo>>("api/Todos");
        }

        public async Task UpdateAsync(Todo todo)
        {
            await _http.PutAsJsonAsync<Todo>($"api/Todos/{todo.Id}", todo);
        }
    }
}
