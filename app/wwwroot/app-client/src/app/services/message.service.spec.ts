import { TestBed, inject } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';

import { MessageService } from './message.service';

describe('MessageService', () => {
	const httpSrvSpy = jasmine.createSpyObj('HttpClient', ['get', 'post']);

	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				MessageService,
				{ provide: HttpClient, useValue: httpSrvSpy }
			]
		});
	});

	it('should be created', inject([MessageService], (service: MessageService) => {
		expect(service).toBeTruthy();
	}));
});
