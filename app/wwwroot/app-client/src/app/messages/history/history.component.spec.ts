import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { HistoryComponent } from './history.component';

describe('HistoryComponent', () => {
	let component: HistoryComponent;
	let fixture: ComponentFixture<HistoryComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [ HistoryComponent ],
			imports: [
				FormsModule
			]
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(HistoryComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
