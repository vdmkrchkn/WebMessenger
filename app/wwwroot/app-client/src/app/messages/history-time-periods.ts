export class HistoryTimePeriods {
	begin: string;
	end: string;

	isValid(): boolean {
		return this.begin != null && this.begin != ''
				|| this.end != null && this.end != '';
	}
}
