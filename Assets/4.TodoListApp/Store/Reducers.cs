using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnUIWidgets
{
    public class Reducers
    {
        public static TodoViewState Reduce(TodoViewState previousState, object action)
        {
            switch (action)
            {
                case ListPageModeAction _:
                    return new TodoViewState()
                    {
                        TodoListPageState = TodoListPageMode.List,
                        todos = previousState.todos
                    };
                case FinishedPageModeAction _:
                    return new TodoViewState()
                    {
                        TodoListPageState = TodoListPageMode.Finished,
                        todos = previousState.todos
                    };
                case AddTodoAction addTodoAction:
                    var previousTodos = previousState.todos;
                    previousTodos.Add(new Todo()
                    {
                        Content = addTodoAction.TodoContent
                    });

                    return new TodoViewState()
                    {
                        TodoListPageState = previousState.TodoListPageState,
                        todos = previousTodos
                    };
            };
            return previousState;
        }
    }
}
