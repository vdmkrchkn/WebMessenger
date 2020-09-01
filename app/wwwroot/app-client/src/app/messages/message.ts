// DTO модель сообщения
export class Message {
	constructor(public text: string,
				public userName?: string)
	{ }

	// проверка корректности сообщения
	isValid(): boolean {
		return !!this.text;
	}

	// очистка сообщения
	clear(): void {
		this.text = null;
		this.userName = null;
	}
}
