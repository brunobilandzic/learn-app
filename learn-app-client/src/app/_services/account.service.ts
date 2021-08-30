import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthorizedUser, UsernamePass } from '../_models/help/authorization';
import { ACTION_FAILURE, ACTION_SUCCESS } from '../_models/help/component-communication';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseApiUrl = environment.baseApiUrl + 'account/';

  user = new ReplaySubject<AuthorizedUser>(1);
  user$ = this.user.asObservable();

  constructor(private http: HttpClient) {}

  login(authorization: UsernamePass) {
    return this.http.post(this.baseApiUrl + 'login', authorization)
      .pipe(
        map((response: any) => {
          this.userToStorage(response);
          this.user.next(response);
          return;
        })
      )
  }

  userToStorage(user: AuthorizedUser) {
    localStorage.setItem('authorized-user', JSON.stringify(user));
  }

  userFromStorage() {
    let authorizedUserStringyfied = localStorage.getItem('authorized-user');
    if (authorizedUserStringyfied == null) return;
    this.user.next(JSON.parse(authorizedUserStringyfied));
  }

  logout() {
    localStorage.removeItem('authorized-user');
    this.user.next(undefined)
  }
}
