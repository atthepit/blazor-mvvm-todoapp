using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TodoMvvmApp.Shared;

namespace TodoMvvmApp.Server.Features
{
    public interface ITodosService
    {
        void Add(Todo todo);
        Todo Create(string text, bool done);
        Todo Get(Guid id);
        IEnumerable<Todo> GetAll();
        void Remove(Guid id);
        void Update(Todo todo);
    }

    public class TodosService : ITodosService
    {
        private IList<Todo> Todos { get; set; } = new List<Todo> {
            new Todo() { Text = "Do the laundry", Done = true },
            new Todo() { Text = "Walk the dog", Done = true },
            new Todo() { Text = "Sacrifice neighbour to the gods", Done = false },
        };

        public IEnumerable<Todo> GetAll()
        {
            return Todos;
        }

        public Todo Get(Guid id)
        {
            return Todos.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Todo todo)
        {
            Todos.Add(todo);
        }

        public Todo Create(string text, bool done)
        {
            var todo = new Todo()
            {
                Text = text,
                Done = done
            };
            Todos.Add(todo);
            return todo;
        }

        public void Remove(Guid id)
        {
            var todo = this.Get(id);
            if (todo != null)
                Todos.Remove(todo);
        }

        public void Update(Todo todo)
        {
            var t = Get(todo.Id);
            if (t != null)
            {
                var index = Todos.IndexOf(t);
                Todos[index] = todo;
            }
        }
    }
}
