using GFramework.UIWidgets;
using LearnUIWidgets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class TodoListPage : StatefulWidget
    {
        public override State createState()
        {
            return new TodoListState();
        }
    }
    public enum TodoListPageMode
    {
        List,
        Finished
    }

    class TodoListState : State<TodoListPage>
    {
        private void OnChange()
        {
            setState(() => { });
        }
        public override void deactivate()
        {
        }
        private string mInputContent;
        private List<Todo> mTodoDatas;


        public override Widget build(BuildContext context)
        {
            return new StoreConnector<TodoViewState, TodoViewState>(
                converter:state=>state,
                builder: (buildContext, viewModel, dispatcher) =>
             {
                 if (viewModel.TodoListPageState == TodoListPageMode.List)
                 {
                     return
                         GF.ListView
                             .Child(
                             new TodoInputView(data =>
                             {
                                 dispatcher.dispatch(new AddTodoAction(data));
                             }
                             ))
                             .Children(TodoViews(viewModel.todos))
                             .Padding(EdgeInsets.only(top: 50))
                             .EndListView();
                 }
                 else
                 {
                     return GF.ListView
                             .Children(FinishedViews(viewModel.todos))
                             .Padding(EdgeInsets.only(top: 50))
                             .EndListView();
                 }
             });

        }
        private Widget[] TodoViews(List<Todo> todos)
        {
            var result = new List<Widget>();
            foreach (var item in todos.Where(data => !data.Finished))
            {
                result.Add(new TodoView(item,
                onDelete: () =>
                {
                    this.setState(() =>
                    {
                        todos.Remove(item);
                    });
                },
                onFinish: () =>
                {
                    this.setState(() =>
                    {
                        item.Finished = true;
                    });
                }));
                result.Add(new Divider());
            }
            return result.ToArray();
        }
        private Widget[] FinishedViews(List<Todo> todos)
        {

            var result = new List<Widget>();
            foreach (var item in todos.Where(data => data.Finished))
            {
                result.Add(new TodoView(item,
                onDelete: () =>
                {
                    this.setState(() =>
                    {
                        todos.Remove(item);
                    });
                },
                onFinish: () =>
                {
                    this.setState(() =>
                    {
                        item.Finished = true;
                    });
                }));
                result.Add(new Divider());
            }
            return result.ToArray();
        }
    }
}
