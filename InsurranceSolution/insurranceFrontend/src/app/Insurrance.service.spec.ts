import { TestBed, inject } from '@angular/core/testing';

import { InsurranceService } from './Insurrance.service';

describe('InsurranceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InsurranceService]
    });
  });

  it('should be created', inject([InsurranceService], (service: InsurranceService) => {
    expect(service).toBeTruthy();
  }));
});
