import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { count, defaultIfEmpty, finalize, isEmpty, map, take } from 'rxjs/operators';
import { UsernamePass } from '../_models/help/authorization';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  authorizationForm: UsernamePass = {
    username: '',
    password: '',
  };
  constructor(public accountService: AccountService, private router: Router) {}

  ngOnInit(): void {
    this.accountService.user$
      .subscribe(user => {
        if(user == undefined) {
          this.router.navigateByUrl("register");
        }
      
      });
  }
  navigateToRegister()
  {
  }
  onLogin() {
    this.accountService.login(this.authorizationForm).subscribe(() => {});
  }
}
