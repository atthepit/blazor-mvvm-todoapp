using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoMvvmApp.Shared;

using TodoMvvmApp.Client.Services;

namespace TodoMvvmApp.Client.ViewModels
{
    public class TodosViewModel : AsyncViewModel
    {
        private readonly ITodosService _todosService;

        public TodosViewModel(ITodosService todosService)
        {
            _todosService = todosService;
        }

        private List<Todo> todos = new List<Todo>();
        public List<Todo> Todos
        {
            get => todos;
            private set
            {
                SetValue(ref todos, value);
            }
        }

        private Todo selectedTodo = new Todo();
        public Todo SelectedTodo
        {
            get => selectedTodo;
            private set
            {
                SetValue(ref selectedTodo, value);
            }
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            StartAsyncOperation();
            var result = await _todosService.GetAllAsync();
            EndAsyncOperation();
            todos = result.ToList();
            return result;
        }

        public Todo Get(Guid id)
        {
            return todos.FirstOrDefault(t => t.Id == id);
        }

        public async Task AddAsync(Todo todo)
        {
            // Add validations
            StartAsyncOperation();
            await _todosService.AddAsync(todo);
            EndAsyncOperation();
            OnPropertyChanged(nameof(Todos));
            selectedTodo = new Todo();
            OnPropertyChanged(nameof(SelectedTodo));
        }

        public async Task UpdateAsync(Todo todo)
        {
            // Add validations
            StartAsyncOperation();
            await _todosService.UpdateAsync(todo);
            EndAsyncOperation();
            OnPropertyChanged(nameof(Todos));
            selectedTodo = new Todo();
            OnPropertyChanged(nameof(SelectedTodo));
        }

        public async Task SaveAsync(Todo todo)
        {
            if (todos.Any(t => t.Id == todo.Id))
                await UpdateAsync(todo);
            else
                await AddAsync(todo);
        }

        public async Task DeleteAsync(Todo todo)
        {
            StartAsyncOperation();
            await _todosService.DeleteAsync(todo);
            EndAsyncOperation();
            OnPropertyChanged(nameof(Todos));
        }

        public void SelectTodo(Todo todo)
        {
            selectedTodo = Todo.Copy(todo);
            OnPropertyChanged(nameof(SelectedTodo));
        }

        public void ClearSelected()
        {
            selectedTodo = new Todo();
            OnPropertyChanged(nameof(SelectedTodo));
        }
    }
}
