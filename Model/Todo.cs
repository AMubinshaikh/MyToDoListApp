using System;
namespace MyTodoApp_ISG.Model {
    public class Todo {

        public int Id { get; set; }
        public string WorkTodo { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}