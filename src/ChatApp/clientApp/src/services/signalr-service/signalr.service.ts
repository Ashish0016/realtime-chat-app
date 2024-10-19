import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  private hubConnection!: HubConnection;

  constructor() {
    this.createHubConnection();
  }

  createHubConnection() {
    // Establishing connection the specified hub which is chat-hub.
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:44301/chat-hub')
      .build();

    this.startHubConnection();
  }

  startHubConnection() {
    // Starting the connection and looging exception
    this.hubConnection
      .start()
      .then(() => this.listenInvokedMethod())
      .catch((error) => console.log(error));
  }

  listenInvokedMethod() {
    this.hubConnection.off("RecivedMessage");
    this.hubConnection.on("RecivedMessage", (connectionId, message) => {
      console.log(`RecivedMessage with connectId:${connectionId} and message:${message}`);
    })
  }

  sendMessage(message: string) {
    if (!message) message = 'This is default message.'
    this.hubConnection.invoke('SendMessage', message);
  }
}
