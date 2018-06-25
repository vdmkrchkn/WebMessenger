import { Component, OnInit } from '@angular/core';

import { Message } from '../message';
import { MessageService } from '../../services/message.service';
import { HistoryTimePeriods } from '../history-time-periods';

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
		  msgSrv.hours = 2;
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

	loadMessages(times?: HistoryTimePeriods) {
		this.msgSrv.getMessages(times)
			.subscribe(
				data => this.messages = data,
				error => console.error(error)
			)
	}
}
