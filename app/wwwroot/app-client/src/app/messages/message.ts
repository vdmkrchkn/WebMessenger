export class Message {
	constructor(public id: number,
				public text: string,
				public userName?: string,
				public createDateTime?: Date) { }

	isValid(): boolean {
		return this.text != null && this.text != '';
	}
}
