import { Message } from "./message";

describe('Message class', () => {
	it('should create an instance of Message', () => {
        expect(new Message('')).toBeTruthy();
	});

	it('message with some text should be valid', () => {
		let msg = new Message('test');
        expect(msg.isValid()).toBeTruthy();
	});

	it('message with empty text should be invalid', () => {
		let msg = new Message('');
        expect(msg.isValid()).toBeFalsy();
	});

	it('message should be cleared', () => {
		let msg = new Message('test', 'tester');
		msg.clear();

		expect(msg.isValid()).toBeFalsy();
		expect(msg.userName).toBeNull();
	});
})
