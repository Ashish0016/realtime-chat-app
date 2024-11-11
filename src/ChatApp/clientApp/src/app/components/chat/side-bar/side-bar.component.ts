import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {

  public users = [
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Ashish Naikwadi',
      'lastMessage':"Are you there?"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Dipak Pawale',
      'lastMessage':"hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Shubham Gorde',
      'lastMessage':"hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Suraj Naikwadi',
      'lastMessage':"hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Joe Biden',
      'lastMessage':"hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Mangesh Nehe',
      'lastMessage':"hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Pratiksha Gunjal',
      'lastMessage':"hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name':'Suvarna Jadhav',
      'lastMessage':"hello!"
    },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Dipak Pawale',
    //   'lastMessage':"hello!"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Dipak Pawale',
    //   'lastMessage':"hello!"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Ashish Naikwadi',
    //   'lastMessage':"Are you there?"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Ashish Naikwadi',
    //   'lastMessage':"Are you there?"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Ashish Naikwadi',
    //   'lastMessage':"Are you there?"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Ashish Naikwadi',
    //   'lastMessage':"Are you there?"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Ashish Naikwadi',
    //   'lastMessage':"Are you there?"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Ashish Naikwadi',
    //   'lastMessage':"Are you there?"
    // },
    // {
    //   'avatar': 'fas fa-user text-blue-500 text-2xl',
    //   'name':'Ashish Naikwadi',
    //   'lastMessage':"Are you there?"
    // },
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
