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
                                    return new Dismissible(
                                        key: new ObjectKey(todo),//不加上Key 渲染时候会导致下面的都被清空
                                        child: new ListTile(
                                            title: new Text(todo.Title)
                                            ),
                                        background: new Container(
                                            color: Colors.red,
                                            child: new ListTile(
                                                leading: new Icon(
                                                    icon: Icons.delete,
                                                    color: Colors.white
                                                    )
                                                )
                                            ),
                                        secondaryBackground: new Container(
                                            color: Colors.green,
                                            child: new ListTile(
                                                trailing: new Icon(
                                                    icon: Icons.check,
                                                    color: Colors.white
                                                    )
                                                )
                                            ),
                                        onDismissed: direction =>
                                        {
                                            if (direction == DismissDirection.startToEnd)
                                            {
                                                dispatcher.dispatch(new RemoveTodoAction(todo));
                                            }
                                            else if (direction == DismissDirection.endToStart)
                                            {
                                                dispatcher.dispatch(new CompleteTodoAction(todo));
                                            }
                                        }
                                        );

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
                Todos = todos.Where(todo => todo.Status == filter.TodoStatus).ToList();
            }
            else if(filter.Type==FilterType.ByToday)
            {
                Todos = todos.Where(todo => todo.Deadline == DueDate.Today && todo.Status == TodoStatus.Pending).ToList();
            }
        }
    }
}
