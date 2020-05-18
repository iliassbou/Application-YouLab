import { TestBed } from '@angular/core/testing';

import { DocteurService } from './docteur.service';

describe('DocteurService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DocteurService = TestBed.get(DocteurService);
    expect(service).toBeTruthy();
  });
});
