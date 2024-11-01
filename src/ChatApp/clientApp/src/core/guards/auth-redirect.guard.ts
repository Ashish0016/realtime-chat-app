import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { SharedService } from 'src/services/shared-service/shared.service';

@Injectable({
  providedIn: 'root'
})
export class AuthRedirectGuard implements CanActivate {

  constructor(private router: Router,
    private shared: SharedService
  ) { }

  canActivate(): boolean {
    let isTokenExists: boolean = this.shared.isTokenExists();

    if (isTokenExists) {
      this.router.navigate(['chat']);
      return false;
    } else {
      return true;
    }
  }

}
