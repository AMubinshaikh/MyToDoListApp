import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TodoAddComponent } from './todo-add/todo-add.component';
import { TodoItemComponent } from './todo-item/todo-item.component';
import { TodosListComponent } from './todos-list/todos-list.component';

@NgModule({
  declarations: [
    AppComponent,
    TodoAddComponent,
    TodoItemComponent,
    TodosListComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: TodosListComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
