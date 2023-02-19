import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  // Tip: Using the guard, there is no need to subscribe and unsubscribe an observable
  // The guard is doing it for us. So we are not subscribing the Observable currentUser$
  canActivate(): Observable<boolean>{
    return this.accountService.currentUser$.pipe(
      map(user => {
        if(user) return true;
        else{
          this.toastr.error('You must first login, to enter that section.');
          return false;
        }
      })
    );
  }
  
}
