using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoProApp
{
    public enum FilterType
    {
        InBox,
        Finished
    }
    public class Filter
    {
        public FilterType Type { get; } = FilterType.InBox;
        public string Title { get; } = "收件箱";
        public TodoStatus TodoStatus { get; } = TodoStatus.Pending;
        private Filter(FilterType type,string title,TodoStatus todoStatus)
        {
            TodoStatus = todoStatus;
            Title = title;
            Type = type;
        }
        public static Filter ByInBox()
        {
            return new Filter(FilterType.InBox, "收件箱", TodoStatus.Pending);
        }
        public static Filter ByFinished()
        {
            return new Filter(FilterType.Finished, "已完成", TodoStatus.Complete);
        }
    }
}
