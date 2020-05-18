import { TestBed } from '@angular/core/testing';

import { SecretaireService } from './secretaire.service';

describe('SecretaireService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SecretaireService = TestBed.get(SecretaireService);
    expect(service).toBeTruthy();
  });
});
