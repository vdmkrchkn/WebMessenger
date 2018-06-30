import { Component, Output, EventEmitter } from '@angular/core';

import { HistoryTimePeriods } from '../history-time-periods';

@Component({
  selector: 'msg-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent {
	interval: HistoryTimePeriods;
	// событие готовности выбора временного периода для родительского компонента
	@Output() onApplied = new EventEmitter<HistoryTimePeriods>();
	@Output() onReset = new EventEmitter<any>();

  	constructor() {
		this.interval = new HistoryTimePeriods();
	}

	apply() {
		this.onApplied.emit(this.interval);
	}

	reset() {
		this.interval.clear();
		this.onReset.emit();
	}
}
