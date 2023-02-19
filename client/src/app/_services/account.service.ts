import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})

export class AccountService {

  // Url property is set to the API endpoint for user account management
  baseUrl = 'https://localhost:5001/api/';

  // The initial value is null and its type is User or null
  private currentUserSource = new BehaviorSubject<User | null>(null);

  // Current user is defined as an observable that emits the value of currentUserSource
  // The $ suffix is a convention in Angular to indicate that a property is an observable
  currentUser$ = this.currentUserSource.asObservable();
  
  constructor(private http: HttpClient) { }

  // This method sends a login request to the API and expects a response of type User
  login(model: any) {
    return this.http.post<User>(this.baseUrl+'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if(user) {
          // If a valid user object is returned in the response, it is stored in local storage using localStorage.setItem()
          localStorage.setItem('user', JSON.stringify(user));
          // Method next() of currentUserSource is called to emit the new user object to all subscribers 
          // which notifies any interested components that the current user has changed
          this.currentUserSource.next(user);
        }
      })
    )
  }

  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  // Updates the value of currentUserSource with the provided user object
  // The next method of currentUserSource is called to emit the new user object to all subscribers
  // which notifies any interested components that the current user has changed
  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  // Removes the user object from local storage
  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
