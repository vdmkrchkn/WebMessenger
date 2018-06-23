export class Message {
	constructor(public text: string,
				public userName?: string,
				public createDateTime?: Date)
	{ }

	// проверка корректности сообщения
	isValid(): boolean {
		return this.text != null && this.text != '';
	}

	// очистка сообщения
	clear(): void {
		this.text = '';
		this.userName = null;
		this.createDateTime = null;
	}
}
