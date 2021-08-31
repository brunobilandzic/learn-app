import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerFormGroup: FormGroup;
  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
    ) {}

  ngOnInit(): void {
    this.initializeRegisterFormGroup();    
  }

  initializeRegisterFormGroup() {
    this.registerFormGroup = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(5), Validators.pattern(/^[\w]*$/)]],
      password: ['', [Validators.required,  Validators.minLength(5)]]
    });
  }

  onRegister() {
    this.accountService.register(this.registerFormGroup.value)
    .subscribe(() => {
      this.toastr.success("Successfully registered!");
      this.router.navigateByUrl("");
    })
  }
  resetForm() {
    
    
  }

}
