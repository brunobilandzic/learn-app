import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthorizedUser, UsernamePass } from '../_models/help/authorization';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseApiUrl = environment.baseApiUrl + 'account/';

  user = new ReplaySubject<AuthorizedUser>(1);
  user$ = this.user.asObservable();

  constructor(private http: HttpClient) {
    this.user.next(undefined);
  }

  login(authorization: UsernamePass) {
    return this.http.post(this.baseApiUrl + 'login', authorization).pipe(
      map((response: any) => {
        this.userToStorage(response);
        this.user.next(response);
        return;
      })
    );
  }

  isLoggedIn(): Observable<boolean> {
    return this.user$.pipe(
      map((user) => {
        return user == undefined ? false : true;
      })
    );
  }

  register(registration: UsernamePass) {
    return this.http.post(this.baseApiUrl + 'register', registration).pipe(
      map((response: any) => {
        this.userToStorage(response);
        this.user.next(response);
        return;
      })
    );
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
    this.user.next(undefined);
  }
}
