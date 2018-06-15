import { Message } from "./message";

describe('Message class', () => {

	it('Should create Message invalid object', () => {
		const msg = new Message(-1, '');

		expect(msg.isValid()).toBeFalsy();
	});

	it('Should create Message valid object', () => {
		const msg = new Message(-1, 'test');

		expect(msg.isValid()).toBeTruthy();
	});
})
