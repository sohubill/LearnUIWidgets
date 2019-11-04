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
                    return
                    new Scaffold(
                        appBar: new AppBar(
                            title: new Text(title)
                            ),
                        drawer: new SideDrawer(),
                        body: new TodoTasks(),
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
                        ) ;
                }
                );
        }
    }
}
