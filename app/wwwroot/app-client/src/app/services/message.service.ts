import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { Message } from '../messages/message';
import { HistoryTimePeriods } from '../messages/history-time-periods';

@Injectable()
export class MessageService {
	private url = 'messages';
	hours: number;

  	constructor(private http: HttpClient) { }

	add(msg: Message): Observable<Message> {
		return this.http.post<Message>(this.url, msg);
	}

	getMessages(interval?: HistoryTimePeriods): Observable<Message[]> {
		if (!interval) {
			return this.http.get<Message[]>(`${this.url}/${this.hours}`);
		} else {
			// URL encoded safe search parameter if there are a search periods of dates
			let params = new HttpParams();

			if (interval.begin)
				params = params.set('from', interval.begin);

			if (interval.end)
				params = params.set('to', interval.end);

			return this.http.get<Message[]>(this.url, { params });
		}
	}
}
