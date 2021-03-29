using System;

namespace MyTodoApp_ISG.ViewModel
{
    public class TodoAddViewModel
    {
        public string WorkTodo { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TodoUpdateViewModel
    {
        public string WorkTodo { get; set; }
        public bool IsCompleted { get; set; }
    }
}