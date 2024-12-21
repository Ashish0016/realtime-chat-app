import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/services/shared-service/shared.service';
import { LoggedInUserDetails } from '../../constants/global-constant';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public dropdownOpen: boolean = false;
  public loggedInUserDetails!: LoggedInUserDetails;

  constructor(private sharedService: SharedService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.getLoggedInUserDetails();
  }

  getLoggedInUserDetails() {
    this.http.get('api/user/getLoggedInUserDetails')
      .subscribe((res: any) => {
        this.loggedInUserDetails = {
          id: res.userId,
          name: res.userName,
          email: res.email
        };
      })
  }

  openDropDown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  logout(): void {
    this.sharedService.logout();
  }
}
