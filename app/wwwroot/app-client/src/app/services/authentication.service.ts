import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationClientService } from './authentication-client.service';

@Injectable()
export class AuthenticationService {
  private tokenKey = 'token';
  constructor(
    private router: Router,
    private authService: AuthenticationClientService)
  { }

  isLoggedIn() {
    const token = localStorage.getItem(this.tokenKey);
    return token != null && token.length > 0;
  }

  login(username: string, password: string): void {
    this.authService.login(username, password).subscribe(token => {
      localStorage.setItem(this.tokenKey, token);
      this.router.navigate(['/']);
    });
  }

  register(username: string, password: string): void {
    this.authService.register(username, password).subscribe(token => {
      localStorage.setItem(this.tokenKey, token);
      this.router.navigate(['/']);
    });
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    this.router.navigate(['/login']);
  }
}
