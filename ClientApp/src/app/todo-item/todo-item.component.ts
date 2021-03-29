import { Component, Input, OnInit } from '@angular/core';
import { TodoModel } from '../core/todo.interface';
import { TodoService } from '../core/todo.service';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css']
})
export class TodoItemComponent {
  @Input() item: TodoModel;

  constructor(private todosService:TodoService) { }
  toggleStatus() {
    this.todosService.editItem(this.item);
  }

  removeItem() {
    this.todosService.removeItem(this.item);
  }

  ngOnInit() {
  }

}
