using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnUIWidgets
{
    public  class ViewState
    {
        public static TodoListPageMode TodoListPageState { get; set; } = TodoListPageMode.List;
        public static Action OnChange;
    }
    public class TodoViewState
    {
        public TodoListPageMode TodoListPageState { get; set; } = TodoListPageMode.List;
    }
}
