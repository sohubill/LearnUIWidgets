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
        public override void initState()
        {
            mTodoDatas = Model.Load();
        }
        public override void deactivate()
        {
        }
        private string mInputContent;
        private List<Todo> mTodoDatas;
        private void Save()
        {
            mTodoDatas.Save();
        }

        public override Widget build(BuildContext context)
        {
            return new StoreConnector<TodoViewState, TodoListPageMode>(
                converter:state=>state.TodoListPageState,
                builder: (buildContext, viewModel, dispatcher) =>
             {
                 if (viewModel == TodoListPageMode.List)
                 {
                     return
                         GF.ListView
                             .Child(
                             new TodoInputView(data =>
                             {
                                 setState(() =>
                                 {
                                     mTodoDatas.Add(new Todo() { Content = data });
                                     Save();
                                 });
                             }
                             ))
                             .Children(TodoViews)
                             .Padding(EdgeInsets.only(top: 50))
                             .EndListView();
                 }
                 else
                 {
                     return GF.ListView
                             .Children(FinishedViews)
                             .Padding(EdgeInsets.only(top: 50))
                             .EndListView();
                 }
             });

        }
        private Widget[] TodoViews
        {
            get
            {
                var result = new List<Widget>();
                foreach (var item in mTodoDatas.Where(data => !data.Finished))
                {
                    result.Add(new TodoView(item,
                    onDelete: () =>
                    {
                        this.setState(() =>
                        {
                            mTodoDatas.Remove(item);
                            Save();
                        });
                    },
                    onFinish: () =>
                    {
                        this.setState(() =>
                        {
                            item.Finished = true;
                            Save();
                        });
                    }));
                    result.Add(new Divider());
                }
                return result.ToArray();
            }
        }
        private Widget[] FinishedViews
        {
            get
            {
                var result = new List<Widget>();
                foreach (var item in mTodoDatas.Where(data => data.Finished))
                {
                    result.Add(new TodoView(item,
                    onDelete: () =>
                    {
                        this.setState(() =>
                        {
                            mTodoDatas.Remove(item);
                            Save();
                        });
                    },
                    onFinish: () =>
                    {
                        this.setState(() =>
                        {
                            item.Finished = true;
                            Save();
                        });
                    }));
                    result.Add(new Divider());
                }
                return result.ToArray();
            }
        }
    }
}
