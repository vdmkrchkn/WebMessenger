import { Component, Output, EventEmitter } from '@angular/core';

import { Message } from '../message';
import { MessageService } from '../../services/message.service';

@Component({
	selector: 'msg-add',
	templateUrl: './add.component.html',
	styleUrls: ['./add.component.css']
})
export class AddComponent {
	@Output() onAdded = new EventEmitter<Message>();

	constructor(private msgSrv: MessageService) {}

	add(text: string, userName?: string): boolean {
		const newMsg = new Message(text, userName);
		this.onAdded.emit(newMsg);

		let success = false;

		this.msgSrv.add(newMsg)
			.subscribe(
				(resp) => success = resp,
				error => console.error(error)
			);

		return success;
	}
}
