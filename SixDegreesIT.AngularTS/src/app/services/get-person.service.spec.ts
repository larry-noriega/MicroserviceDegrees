import { TestBed } from '@angular/core/testing';

import { PersonService } from './get-person.service';

describe('GetPersonService', () => {
  let service: PersonService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
