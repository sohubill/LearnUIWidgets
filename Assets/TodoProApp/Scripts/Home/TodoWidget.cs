using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.UIWidgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace TodoProApp
{
    public class TodoWidget:StatelessWidget
    {
        private Todo Todo { get; }
        private Dispatcher Dispatcher { get; }
        public TodoWidget(Todo todo,Dispatcher dispatcher)
        {
            this.Todo = todo;
            this.Dispatcher = dispatcher;
        }
        public override Widget build(BuildContext context)
        {
            return new Dismissible(
                direction:Todo.Deadline==DueDate.Today?DismissDirection.horizontal:DismissDirection.startToEnd,
                key: new ObjectKey(Todo),//不加上Key 渲染时候会导致下面的都被清空
                child: new ListTile(
                    title: new Text(Todo.Title)
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
                        Dispatcher.dispatch(new RemoveTodoAction(Todo));
                    }
                    else if (direction == DismissDirection.endToStart)
                    {
                        Dispatcher.dispatch(new CompleteTodoAction(Todo));
                    }
                }
                );
        }
    }
}
