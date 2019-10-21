using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class TodoListApp : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new TodoListPage();
        }
        class TodoListPage : StatefulWidget
        {
            public override State createState()
            {
                return new TodoListState();
            }
        }
        class TodoListState : State<TodoListPage>
        {
            private List<string> mTodoDatas = new List<string>
            {
                "Hello",
                "Hello"
            };
            private Widget[] TodoViews { get => mTodoDatas.Select(data => new TodoView()).ToArray(); }
            public override Widget build(BuildContext context)
            {
                return GF.ListView.Child(new GestureDetector(
                    child: GF.Container.Child(GF.Text.Data("+").FontSize(30).EndText()).AlignmentCenter().EndContainer(),
                    onTap:()=>
                {
                    setState(() =>
                    {
                        mTodoDatas.Add("Hello");
                    });
                })).
                Children(
               TodoViews
            ).Padding(EdgeInsets.only(top: 50)).EndListView();
            }
        }
    }
}
