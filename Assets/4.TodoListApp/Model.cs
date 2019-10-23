using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LearnUIWidgets
{
    public class Todo
    {
        public string Content { get; set; } = "";
        public bool Finished { get; set; } = false;
    }
    public static class Model
    {
        public static List<Todo> Load()
        {
            var todoListContent = PlayerPrefs.GetString("TODO_LIST_KEY", string.Empty);
            var splitDatas = todoListContent.Split('|');
            var todoDatas = splitDatas.Where(splitData => !string.IsNullOrEmpty(splitData))
                .Select(todoData =>
                {
                    var todo = new Todo();
                    var todoSplitDatas = todoData.Split('@');
                    todo.Content = todoSplitDatas[0];
                    if (todoSplitDatas.Length > 1)
                    {
                        todo.Finished = bool.Parse(todoSplitDatas[1]);
                    }
                    return todo;
                }).ToList();
            return todoDatas;
        }
        public static void Save(this List<Todo> self)
        {
            StringBuilder stringBuilder = new StringBuilder();
            self.ForEach(todoData =>
            {
                stringBuilder.Append(todoData.Content);
                stringBuilder.Append("@");
                stringBuilder.Append(todoData.Finished);
                stringBuilder.Append("|");
            });
            PlayerPrefs.SetString("TODO_LIST_KEY", stringBuilder.ToString());
        }
    }
}
