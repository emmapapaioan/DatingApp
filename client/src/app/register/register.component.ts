import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent { 
  //@Output decorator passes data to the parent component
  @Output() cancelRegister = new EventEmitter(); 

  model: any = {}

  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  ngOnInit() {}

  register() {
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: error => {
        this.toastr.error(error.error),
        console.log(error)
      }
    })
  }

  cancel() {
    this.cancelRegister.emit(false);  
  }
}
