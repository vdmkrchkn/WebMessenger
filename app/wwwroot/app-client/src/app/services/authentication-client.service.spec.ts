import { TestBed, inject } from '@angular/core/testing';

import { AuthenticationClientService } from './authentication-client.service';

describe('AuthenticationClientService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuthenticationClientService]
    });
  });

  it('should be created', inject([AuthenticationClientService], (service: AuthenticationClientService) => {
    expect(service).toBeTruthy();
  }));
});
