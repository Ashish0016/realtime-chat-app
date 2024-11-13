import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor(private router: Router) { }

  setToken = (token: string) => localStorage.setItem('token', token);

  isTokenExists(): boolean {
    let token: string | null = localStorage.getItem('token');
    return token ? true : false;
  }

  logout(): void {
    if (this.isTokenExists()) {
      localStorage.removeItem('token');
      this.router.navigate(['']);
    }
  }
}
