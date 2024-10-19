import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SignalrService } from 'src/services/signalr-service/signalr.service';

@Component({
  selector: 'app-chat-app',
  templateUrl: './chat-app.component.html',
  styleUrls: ['./chat-app.component.scss']
})
export class ChatAppComponent implements OnInit {

  public chatForm!: FormGroup;

  constructor(private signalR: SignalrService,
    private formBuilder: FormBuilder
  ) {
    this.chatForm = this.formBuilder.group({
      message: ['']
    });
  }

  ngOnInit(): void {
    this.signalR.createHubConnection();
  }

  sendMessage() {
    let message = this.chatForm.controls['message'].value;
    this.signalR.sendMessage(message);
  }
}
