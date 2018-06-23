import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormsModule } from '@angular/forms';

import { AddComponent } from './add.component';
import { MessageService } from '../../services/message.service';
import { of } from 'rxjs/observable/of';

describe('AddComponent', () => {
	let component: AddComponent;
	let fixture: ComponentFixture<AddComponent>;
	const msgSrvSpy = jasmine.createSpyObj('MessageService', ['add']);

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [ AddComponent ],
			imports: [
				FormsModule
			],
			providers: [
				{ provide: MessageService, useValue : msgSrvSpy }
			]
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(AddComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});

	it('should add some message', () => {
		msgSrvSpy.add.and.returnValue(of(true));
		const success = component.add();
		expect(success).toBeTruthy();
	});
});
