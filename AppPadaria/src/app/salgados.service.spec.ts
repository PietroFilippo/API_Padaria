import { TestBed } from '@angular/core/testing';

import { SalgadosService } from './salgados.service';

describe('SalgadosService', () => {
  let service: SalgadosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalgadosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
