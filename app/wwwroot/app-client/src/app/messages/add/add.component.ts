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
		let success: boolean;

		this.msgSrv.add(this.msg)
			.subscribe(
				(resp) => {
					this.onAdded.emit(resp);
					// очистка полей ввода
					this.msg.clear();
					success = true;
				},
				error => console.error(error)
			);		

		return success;
	}
}
