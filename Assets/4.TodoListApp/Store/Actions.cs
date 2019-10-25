namespace LearnUIWidgets
{
    public class ListPageModeAction { };
    public class FinishedPageModeAction { };
    public class AddTodoAction
    {
        public string TodoContent { get;}
        public AddTodoAction(string todoContent)
        {
            TodoContent = todoContent;
        }
    }
}