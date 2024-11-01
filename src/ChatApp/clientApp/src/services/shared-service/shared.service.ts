import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }

  setToken = (token: string) => localStorage.setItem('token', token);

  isTokenExists(): boolean {
    let token: string | null = localStorage.getItem('token');
    return token ? true : false;
  }
}
