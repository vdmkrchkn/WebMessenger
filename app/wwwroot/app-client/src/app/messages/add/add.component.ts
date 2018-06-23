import { Component, Output, EventEmitter } from '@angular/core';

import { Message } from '../message';
import { MessageService } from '../../services/message.service';

@Component({
	selector: 'msg-add',
	templateUrl: './add.component.html',
	styleUrls: ['./add.component.css']
})
export class AddComponent {
	// сообщения для шаблона html
	msg: Message;
	// событие добавления нового сообщения для родительского компонента
	@Output() onAdded = new EventEmitter<Message>();

	constructor(private msgSrv: MessageService) {
		this.msg = new Message('');
	}

	add(): boolean {
		const newMsg = new Message(this.msg.text, this.msg.userName);
		this.onAdded.emit(newMsg);

		let success = false;

		this.msgSrv.add(this.msg)
			.subscribe(
				(resp) => success = resp,
				error => console.error(error)
			);

		// очистка полей ввода
		this.msg.clear();

		return success;
	}
}
