using System.Collections;
using System.Collections.Generic;
using UIWidgets.Runtime.material;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace TodoProApp
{
    public class AddTodoPage : StatelessWidget
    {
        private GlobalKey<FormState> formState = GlobalKey<FormState>.key();
        Todo todo = new Todo();
        public override Widget build(BuildContext context)
        {
            return new Scaffold(
                appBar: new AppBar(
                    title: new Text("Add Todo"),
                    leading: new IconButton(
                        icon: new Icon(
                            icon: Icons.arrow_back
                            ),
                        onPressed: () =>
                        {
                            Navigator.pop(context);
                        }
                        )
                    ),
                body: new Padding(
                    padding: EdgeInsets.all(10),
                    child: new Form(
                        key: formState,
                        child: new TextFormField(
                            onSaved: value => todo.Title = value,
                            decoration: new InputDecoration(
                                hintText: "title"
                                ),
                            validator: value =>
                            {
                                return string.IsNullOrEmpty(value) ? "Title can't be empty" : null;
                            }
                            )
                        )
                    ),
                floatingActionButton: new StoreConnector<AppState, AppState>(
                    converter: state => state,
                    builder: (context2, model, dispatcher) =>
                    {
                        return new FloatingActionButton(
                            child: new Icon(
                                icon: Icons.send
                                ),
                            onPressed: () =>
                            {
                                if (formState.currentState.validate())
                                {
                                    formState.currentState.save();
                                    dispatcher.dispatch(new AddTodoAction(todo));
                                    Navigator.pop(context);
                                }

                            }
                            );
                    }
                    )
                );

        }
    }
}
