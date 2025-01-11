import { Component, OnInit } from '@angular/core';
import { ChatContact } from '../../constants/global-constant';
import { AddConnectionComponent } from '../add-connection/add-connection.component';
import { MatDialog } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {

  // public chatContacts!: ChatContact[];
  public chatContacts: ChatContact[] = [
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Ashish Naikwadi',
      'lastMessage': "Are you there?"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Dipak Pawale',
      'lastMessage': "hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Shubham Gorde',
      'lastMessage': "hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Suraj Naikwadi',
      'lastMessage': "hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Joe Biden',
      'lastMessage': "hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Mangesh Nehe',
      'lastMessage': "hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Pratiksha Gunjal',
      'lastMessage': "hello!"
    },
    {
      'avatar': 'fas fa-user text-blue-500 text-2xl',
      'name': 'Suvarna Jadhav',
      'lastMessage': "hello!"
    }
  ];

  public selectedUser = (this.chatContacts && this.chatContacts.length > 0) ? this.chatContacts[0] : undefined;

  constructor(private dialog: MatDialog,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.getAllAvailableUsersToChat();
  }

  setActiveUser(user: any) {
    this.selectedUser = user;
  }

  getAllAvailableUsersToChat() {
    this.http.get('api/connection/getAllConnectedUsersToChat')
      .subscribe((res: any) => {
        if (!res) return;

        res.forEach((prop: any) => {
          prop['avatar'] = 'fas fa-user text-blue-500 text-2xl';
          prop['lastMessage'] = "hello!";
        });

        this.chatContacts = res;
      })
  }

  openAddConnectionDialog() {
    const dialogRef = this.dialog.open(AddConnectionComponent, {
      width: '70vw',
      height: '80vh',
    })

    dialogRef
      .afterClosed()
      .subscribe((res) => {
        this.getAllAvailableUsersToChat();
      });
  }
}
