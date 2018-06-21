import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { Message } from '../messages/message';

@Injectable()
export class MessageService {
	private url = 'messages';

  	constructor(private http: HttpClient) { }

	add(msg: Message) {
		return this.http.post<boolean>(this.url, msg);
	}

	getMessages(from?: Date, to?: Date): Observable<Message[]> {
		// URL encoded safe search parameter if there is a search periods of dates
		const options = from && to ?
			{ params: new HttpParams().set('from', from.toDateString()).set('to', to.toDateString()) } : {};
		return this.http.get<Message[]>(this.url, options);
	}
}
