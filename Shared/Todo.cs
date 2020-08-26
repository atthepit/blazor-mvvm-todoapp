using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoMvvmApp.Shared
{
    public class Todo
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Text { get; set; }
        [DefaultValue(false)]
        public bool Done { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
        }

        public static Todo Copy(Todo todo)
        {
            return new Todo()
            {
                Id = todo.Id,
                Text = todo.Text,
                Done = todo.Done
            };
        }

        public static void Copy(Todo to, Todo from)
        {
            to.Done = from.Done;
            to.Text = from.Text;
        }
    }
}
