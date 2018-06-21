import { Component, OnInit } from '@angular/core';

import { Message } from '../message';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'msg-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
 	// выбранный пользователь
 	selectedMessage: Message;
	// набор пользователей
	messages: Message[];

  	constructor(private msgSrv: MessageService) { }

  	ngOnInit() {
		  this.msgSrv.getMessages()
		  	.subscribe(
				  data => this.messages = data,
				  error => console.error(error)
			)
	}

	onSelect(msg: Message) {
		this.selectedMessage = msg;
	}
}
