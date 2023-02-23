import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({ //Decorator
  selector: 'app-root', //If we want to make use of this component, we use the name of the selector
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Dating Application';

  // http and accountService properties are injected into the component's constructor 
  // using Angular's dependency injection mechanism
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.setCurrentUser();
  }

  // Gets the current user from local storage and sets it 
  // as the current user of the AccountService
  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (userString) {
      const user: User = JSON.parse(userString);
      this.accountService.setCurrentUser(user);
    }
  }

}
