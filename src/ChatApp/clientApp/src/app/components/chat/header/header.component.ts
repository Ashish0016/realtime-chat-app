import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/services/shared-service/shared.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public dropdownOpen: boolean = false;

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
  }

  openDropDown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  logout(): void {
    this.sharedService.logout();
  }
}
