import { Component } from '@angular/core';

import { Message } from '../message';
import { MessageService } from '../../services/message.service';

@Component({
	selector: 'msg-add',
	templateUrl: './add.component.html',
	styleUrls: ['./add.component.css']
})
export class AddComponent {
	newMsg: Message;

	constructor(private msgSrv: MessageService) {
		this.newMsg = new Message(-1, '');
	}

	add(): boolean {
		let success = false;

		this.msgSrv.add(this.newMsg)
			.subscribe(
				(resp) => success = resp,
				error => console.error(error)
			);

		return success;
	}
}
