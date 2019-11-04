using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoProApp
{
    public enum TodoStatus
    {
        Pending,
        Complete
    }
    public enum DueDate
    {
        None,
        Today,
        Next7Day
    }
    public class Todo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public TodoStatus Status { get; set; } = TodoStatus.Pending;
        public DueDate Deadline { get; set; }
    }
}
