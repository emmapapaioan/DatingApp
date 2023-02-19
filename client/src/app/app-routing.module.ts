import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';

// Initializes a constant variable routes of type Routes, 
// which is an interface defined in Angular to represent an array of routes
// Each route is represented as an object with a path property and a component property
// The path property specifies the URL path for the route, while the component property 
// specifies the component that should be displayed when the route is navigated to
const routes: Routes = [
  // An empty path route that displays the HomeComponent
  {path: '', component: HomeComponent},
  // Guarded
  {path: '',
    runGuardsAndResolvers:'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent},
      {path: 'members/:id', component: MemberDetailComponent},
      {path: 'lists', component: ListsComponent},
      {path: 'messages', component: MessagesComponent},
    ]},
  // A catch-all route with a path of ** that displays the HomeComponent 
  //This route will match any URL that doesn't match the other defined routes.
  {path: '**', component: HomeComponent, pathMatch: 'full'} 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
