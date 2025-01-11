import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-connection',
  templateUrl: './add-connection.component.html',
  styleUrls: ['./add-connection.component.scss']
})
export class AddConnectionComponent implements OnInit {

  public dataSource = new MatTableDataSource<any>();
  public displayedColumns = ['SelectUserCheckBox', 'No', 'UserName'];
  public hasAnyUserSelection: boolean = false;

  constructor(private http: HttpClient,
    private dialogRef: MatDialogRef<AddConnectionComponent>,
    private toaster: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAvailableUsersToConnect();
  }

  getAvailableUsersToConnect(): void {
    const HttpRequestBody = {
      userName: undefined,
      pageSize: 10,
      pageNumber: 0
    };

    this.http.post('api/connection/getAvailableUsersToConnect', HttpRequestBody)
      .subscribe((res: any) => {
        console.log(res);
        const users = res.userList;
        users.forEach((element: any, index: number) => {
          element['no'] = index + 1;
          element['checked'] = false;
        });

        this.dataSource = new MatTableDataSource(res.userList);
      })
  }

  changeUserSelection(element: any, $event: any): void {
    console.log($event)
    this.dataSource.data.forEach((prop) => {
      if (prop.userId === element.userId) {
        prop.checked = $event.checked;
      }
    });

    this.hasAnyUserSelection = this.dataSource.data.some((prop) => prop.checked);
  }

  createUserConnection() {
    let selectedUsers: string[] = this.dataSource.data
      .filter(prop => prop.checked)
      .map(p => p.userId);

    if(selectedUsers.length == 0) return;

    this.http.post('api/connection/AddConnectionToUser', {connectedToUserIds : selectedUsers})
      .subscribe((prop:any) => {
        this.toaster.success("User are connected successfully!");
        this.dialogRef.close();
      });
  }
}
