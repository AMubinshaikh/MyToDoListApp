import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-todos-list',
  templateUrl: './todos-list.component.html',
  styleUrls: ['./todos-list.component.css']
})
export class TodosListComponent {
  @Input() items;
  constructor() { }

  ngOnInit() {
  }

}
