import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model : any = {};

  // Initializing the accountService property with an instance of the AccountService 
  // injected by Angular's dependency injection system
  constructor(public accountService: AccountService) { }

  // Runs when the component is initialized and it sets the currentUser$ observable 
  // to the value of the currentUser$ observable of the AccountService
  ngOnInit(): void {
  }

  // Calling the login method of the accountService with the user's credentials and 
  // subscribing to the response to handle the success or failure of the login attempt
  // Since this is an HTTP request, it is not essential to unsubscribe***
  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => console.log(error)
    })
  }

  // Calling the logout method of the accountService to log the user out
  logout() {
    this.accountService.logout();
  }
}
