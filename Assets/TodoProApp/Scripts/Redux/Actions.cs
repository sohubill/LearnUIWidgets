using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoProApp
{
    public class AddTodoAction
    {
        public Todo Todo { get; }
        public AddTodoAction(Todo todo)
        {
            this.Todo = todo;
        }
        
    }
    public class RemoveTodoAction
    {
        public Todo Todo { get; }
        public RemoveTodoAction(Todo todo)
        {
            Todo = todo;
        }
    }
    public class CompleteTodoAction
    {
        public Todo Todo { get; }
        public CompleteTodoAction(Todo todo)
        {
            Todo = todo;
        }
    }
    public class ApplyFilterAcion
    {
        public Filter Filter { get; }
        public ApplyFilterAcion(Filter filter)
        {
            Filter = filter;
        }
    }
}
