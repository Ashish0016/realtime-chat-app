import { Component, OnInit } from '@angular/core';
import { MessageType } from '../../constants/global-constant';

@Component({
  selector: 'app-messaging',
  templateUrl: './messaging.component.html',
  styleUrls: ['./messaging.component.scss']
})
export class MessagingComponent implements OnInit {

  public MessageType = MessageType;

  chats = [
    {
      message: 'Hi',
      messageType: MessageType.Recieved,
      time: '1:00'
    },
    {
      message: 'Hello',
      MessageType: MessageType.Send,
      time: '1:04'
    },
    {
      message: 'How are you?',
      MessageType: MessageType.Send,
      time: '1:05'
    },
    {
      message: 'I am fine! what about you?',
      MessageType: MessageType.Recieved,
      time: '1:10'
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
