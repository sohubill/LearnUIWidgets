using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoProApp
{
    public class AppReducer
    {
        public static AppState Reduce(AppState state,object action)
        {
            switch (action)
            {
                case AddTodoAction add:
                    state.Todos.Add(add.Todo);
                    break;
                case RemoveTodoAction remove:
                    state.Todos.Remove(remove.Todo);
                    break;
                case CompleteTodoAction complete:
                    complete.Todo.Status = TodoStatus.Complete;
                    break;
                case ApplyFilterAcion filter:
                    state.Filter = filter.Filter;
                    break;
            }
            return state;
        }
    }
}
