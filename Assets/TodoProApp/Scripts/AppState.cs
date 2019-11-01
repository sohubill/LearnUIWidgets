using QFramework.UIWidgets.ReduxPersist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TodoProApp
{

    public class AppState:AbstractPersistState<AppState>
    {
        public Filter Filter { get; set; } = Filter.ByInBox();
        public List<Todo> Todos { get; set; } = new List<Todo>();
        //public AppState()
        //{
        //    Todos.Add(new Todo());
        //    Todos[0].Title = "初始化";
        //}
    }
}
