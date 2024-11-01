import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { SharedService } from 'src/services/shared-service/shared.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private route: Router,
    private sharedService: SharedService
  ) { }

  canActivate(): boolean {
    if (this.sharedService.isTokenExists()) {
      return true;
    } else {
      this.route.navigate(['login']);
      return false;
    }
  }

}
