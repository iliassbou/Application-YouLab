import { TestBed } from '@angular/core/testing';

import { LaborantinService } from './laborantin.service';

describe('LaborantinService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LaborantinService = TestBed.get(LaborantinService);
    expect(service).toBeTruthy();
  });
});
