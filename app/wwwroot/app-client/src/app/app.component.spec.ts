import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { APP_BASE_HREF } from '@angular/common';
import { By } from '@angular/platform-browser';

import { of } from 'rxjs/observable/of';

import { AppComponent } from './app.component';
import { ListComponent } from './messages/list/list.component';
import { AddComponent } from './messages/add/add.component';
import { MessageService } from './services/message.service';

describe('AppComponent', () => {
	let fixture: ComponentFixture<AppComponent>;
	let component: AppComponent;
	let element;

	const msgSrvSpy = jasmine.createSpyObj('MessageService', ['getMessages', 'add']);
	const title = 'WebMessenger';

	beforeEach(async(() => {
		TestBed.configureTestingModule({
		declarations: [
			AppComponent,
			ListComponent,
			AddComponent
		],
		imports: [
			FormsModule
		],
		providers: [
			{ provide: APP_BASE_HREF, useValue : '/' },
			{ provide: MessageService, useValue : msgSrvSpy }
		]
		}).compileComponents();
	}));

	beforeEach(() => {
		msgSrvSpy.getMessages.and.returnValue(of([]));
		fixture = TestBed.createComponent(AppComponent);
		component = fixture.componentInstance;
		const compDe = fixture.debugElement.query(By.css('div'));
		element = compDe.nativeElement;
	});

	it('should create the app', async(() => {
		expect(component).toBeTruthy();
	}));

	it(`should have as title ${title}`, async(() => {
		expect(component.title).toEqual(title);
	}));

	it('should render title in a h1 tag', async(() => {
		fixture.detectChanges();
		const compiled = fixture.debugElement.nativeElement;
		expect(compiled.querySelector('h1').textContent).toContain(`Welcome to ${title}!`);
	}));

	it('should have templates of the list of messages & form 4 adding new one', async(() => {
		expect(element.innerHTML).toContain('msg-list', 'component template doesn\'t contain list of messages');
		expect(element.innerHTML).toContain('msg-add');
	}));
});
