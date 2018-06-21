import { Component, OnInit } from '@angular/core';

import { Message } from '../message';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'msg-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
 	// выбранное сообщение
 	selectedMessage: Message;
	// набор сообщений
	messages: Message[];

  	constructor(private msgSrv: MessageService) {
		  this.messages = [];
	   }

	ngOnInit() {
		this.loadMessages();
	}

	onSelect(msg: Message) {
		this.selectedMessage = msg;
	}

	onAdded(msg: Message) {
		this.messages.push(msg);
	}

	loadMessages() {
		this.msgSrv.getMessages()
			.subscribe(
				data => this.messages = data,
				error => console.error(error)
			)
	}
}
