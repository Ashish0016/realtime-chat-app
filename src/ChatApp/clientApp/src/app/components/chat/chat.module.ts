import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChatRoutingModule } from './chat-routing.module';
import { LayoutComponent } from './layout/layout.component';
import { HeaderComponent } from './header/header.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { MessagingComponent } from './messaging/messaging.component';
import { AddConnectionComponent } from './add-connection/add-connection.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table'
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';


@NgModule({
  declarations: [
    LayoutComponent,
    HeaderComponent,
    SideBarComponent,
    MessagingComponent,
    AddConnectionComponent
  ],
  imports: [
    CommonModule,
    ChatRoutingModule,
    MatDialogModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatCheckboxModule
  ]
})
export class ChatModule { }
