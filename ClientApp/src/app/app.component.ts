import { Component, OnDestroy, OnInit } from '@angular/core';
import { TodoModel } from './core/todo.interface';
import { TodoService } from './core/todo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit, OnDestroy{
  title = 'app';
  constructor(private todosService:TodoService) {
  }
  items:any[] = [];
  ngOnInit() {
    if (localStorage.getItem('items')) {
      this.items = [...JSON.parse(localStorage.getItem('items'))];
    }
    this.getTodos();
    this.getNewTodos();
    this.checkTodosToRemove();
    this.checkTodosToEdit();
  }

  ngOnDestroy() {
    this.todosSub.unsubscribe();
    if(this.saveTodosSub) { this.saveTodosSub.unsubscribe(); }
    if(this.removeItem$Sub) { this.removeItem$Sub.unsubscribe(); }
    if(this.editItem$Sub) { this.editItem$Sub.unsubscribe(); }
  }

  removeItem$Sub;
  checkTodosToRemove() {
    this.removeItem$Sub = this.todosService.removeItem$.subscribe((item: TodoModel) => {
      console.log('new item', item)

      if(item) {
        this.items = this.items.filter(current => current.id != item.id);
      }
    });
  }

  editItem$Sub;
  checkTodosToEdit() {
    this.editItem$Sub = this.todosService.editItem$.subscribe((item: TodoModel) => {
      if(item) {
        for (let i of this.items) {
          if (i.id === item.id) {
            i.completed = !item.completed;
          }
        }
      }
    });
  }

  todosSub;
  getTodos() {
    this.todosSub = this.todosService.getTodos().subscribe((todos:TodoModel[]) => {
      this.items = [...todos];
    });
  }

  getNewTodosSub;
  getNewTodos() {
    this.getNewTodosSub = this.todosService.addItem$.subscribe((todos:TodoService) => {
      this.items.push(todos);
    });
  }

  saveTodosSub;
  saveToDB() {
    this.saveTodosSub = this.todosService.saveTodos(this.items).subscribe((res:any) => {
      this.saveTodosSub.unsubscribe();
      console.log(res);
    });
  }
}
