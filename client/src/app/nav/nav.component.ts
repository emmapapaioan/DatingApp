import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent implements OnInit {
  model: any = {};
  // Initializes the accountService and router dependencies as public and private properties respectively 
  // This allows the component to use the AccountService to handle user authentication, the Router to 
  // navigate between different views in the application and the ToastrService to display an error properly
  constructor(public accountService: AccountService, private router: Router,
    private toastr: ToastrService) { }

  // Runs when the component is initialized and it sets the currentUser$ observable 
  // to the value of the currentUser$ observable of the AccountService
  ngOnInit(): void {
  }

  // ***Since this is an HTTP request, it is not essential to unsubscribe after***
  // Calls the login() method of the accountService with the user's credentials and subscribes to the response
  // If the login attempt is successful, navigates the user to the /members page
  login() {
    this.accountService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/members')
    })
  }

  // Calling the logout method of the accountService to log the user out
  // Navigates user back to the root page 
  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
