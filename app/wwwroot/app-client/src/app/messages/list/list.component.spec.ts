import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { of } from 'rxjs/observable/of';

import { ListComponent } from './list.component';
import { MessageService } from '../../services/message.service';

describe('ListComponent', () => {
	let component: ListComponent;
	let fixture: ComponentFixture<ListComponent>;
	const msgSrvSpy = jasmine.createSpyObj('MessageService', ['getMessages']);

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [ ListComponent ],
			imports: [
				FormsModule
			],
			providers: [
				{ provide: MessageService, useValue : msgSrvSpy }
			]
		}).compileComponents();
	}));

	beforeEach(() => {
		msgSrvSpy.getMessages.and.returnValue(of([]));
		fixture = TestBed.createComponent(ListComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
