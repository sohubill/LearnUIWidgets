using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.UIWidgets.material;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;

namespace TodoProApp
{
    public class TodoTasks:StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return new StoreConnector<AppState, TodoTasksViewModel>(
                converter:state=>new TodoTasksViewModel(state.Filter,state.Todos),
                builder: (buildContext, model, dispatcher) =>
                {
                    return model.Todos.Count == 0 ? new Container() : new Container(
                        child: ListView.builder(
                                itemCount: model.Todos.Count,
                                itemBuilder: (con, index) =>
                                {
                                    var todo = model.Todos[index];
                                    return new TodoWidget(model.Todos[index],dispatcher);

                                }
                        )
                    );
                }
                );
        }
    }

    class TodoTasksViewModel
    {
        public List<Todo> Todos { get; }
        public TodoTasksViewModel(Filter filter,List<Todo> todos)
        {
            if (filter.Type==FilterType.ByStatus)
            {
                if (filter.TodoStatus==TodoStatus.Pending)
                {
                    Todos = todos.Where(todo => (todo.Status == filter.TodoStatus && todo.Deadline!=DueDate.Today)).ToList();
                }
                else
                {
                    Todos = todos.Where(todo => (todo.Status == filter.TodoStatus )).ToList();
                }
               
            }
            else if(filter.Type==FilterType.ByToday)
            {
                Todos = todos.Where(todo => todo.Deadline == DueDate.Today && todo.Status == TodoStatus.Pending).ToList();
            }
        }
    }
}
