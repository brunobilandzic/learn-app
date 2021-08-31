import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  constructor(public accountService: AccountService, public router: Router) {}

  ngOnInit(): void {
    this.accountService.isLoggedIn().subscribe((isLoggedIn) => {
      if (isLoggedIn == false) this.router.navigateByUrl('register');
    });
  }
  navigateToRegister() {}
  onLogin() {
    this.accountService.login(this.authorizationForm).subscribe(() => {
      this.router.navigateByUrl("");
    });
  }
}
