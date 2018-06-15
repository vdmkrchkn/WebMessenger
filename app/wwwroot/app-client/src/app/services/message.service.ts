import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { Message } from '../messages/message';

@Injectable()
export class MessageService {
	private url = 'api/messages';

  	constructor(private http: HttpClient) { }

	add(msg: Message) {
		return this.http.post<boolean>('api/add', msg);
	}

	getMessages(): Observable<Message[]> {
		return this.http.get<Message[]>(this.url);
	}
}
