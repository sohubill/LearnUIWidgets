using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.UIWidgets.material;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace TodoProApp
{
    public class Home : StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return new StoreConnector<AppState, AppState>(
                converter: state => state,
                builder: (buildContext, model, dispatcher) =>
                {
                    string title = model.Filter.Title;
                    List<Todo> todos = model.Todos.Where(item => item.Status == model.Filter.TodoStatus).ToList();
                    return
                    new Scaffold(
                        appBar: new AppBar(
                            title: new Text(title)
                            ),
                        drawer: new SideDrawer(),
                        body: todos.Count == 0 ? new Container() : new Container(child: ListView.builder(
                                    itemCount: todos.Count,
                                    itemBuilder: (con, index) =>
                                    {
                                        var todo = todos[index];
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
                            ),
                        floatingActionButton: new FloatingActionButton(
                            child: new Icon(
                                icon: Icons.add),
                            onPressed: () =>
                            {
                                Navigator.push(
                                    context,
                                    new MaterialPageRoute(
                                        builder: buildContext1 => new AddTodoPage()
                                        )
                                    );
                            }
                            )
                        );
                }
                );
        }
    }
}
