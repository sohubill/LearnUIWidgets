using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoProApp
{
    public enum FilterType
    {
        ByStatus,
        ByToday
    }
    public static class TodoStatusToTitle
    {
        public static string ToTitle(this TodoStatus status)
        {
            return status == TodoStatus.Pending ? "收件箱" : "已完成";
        }
    }
    public class Filter
    {
        public FilterType Type { get; } = FilterType.ByStatus;
        public string Title { get; } = "收件箱";
        public TodoStatus TodoStatus { get; } = TodoStatus.Pending;
        private Filter(FilterType type,string title,TodoStatus todoStatus)
        {
            TodoStatus = todoStatus;
            Title = title;
            Type = type;
        }
        public static Filter ByStatus(TodoStatus status)
        {

            return new Filter(FilterType.ByStatus, status.ToTitle(), status);
        }
        public static Filter ByToday()
        {
            return new Filter(FilterType.ByToday, "今天", TodoStatus.Pending);
        }


    }
}
