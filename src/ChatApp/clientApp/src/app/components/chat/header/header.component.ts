import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public dropdownOpen:boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  openDropDown(){
    this.dropdownOpen = !this.dropdownOpen;
  }
}
