import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class AuthenticationClientService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<string> {
    return this.http.post('/user/login', { username, password }, { responseType: 'text' });
  }

  public register(username: string, password: string): Observable<string> {
    return this.http.post(
      '/user/register',
      {
        username,
        password,
      },
      { responseType: 'text' }
    );
  }
}
