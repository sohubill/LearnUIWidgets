using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnUIWidgets
{
    public  class ViewState
    {
        public static PageState TodoListPageState { get; set; } = PageState.List;
        public static Action OnChange;
    }
}
