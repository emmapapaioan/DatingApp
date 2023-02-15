import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({ //Decorator
  selector: 'app-root', //If we want to make use of this component, we use the name of the selector
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Dating Application';
  users: any; //Whatever..

  constructor(private http: HttpClient){}

  ngOnInit(): void{
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed!')
    })
  }

}
