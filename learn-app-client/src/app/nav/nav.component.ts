import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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
  constructor(public accountService: AccountService) {}

  ngOnInit(): void {}

  onLogin() {
    this.accountService.login(this.authorizationForm).subscribe(() => {});
  }
}
