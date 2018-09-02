import { TestBed, inject } from '@angular/core/testing';

import { TiposCubrimientoService } from './TiposCubrimiento.service';

describe('TiposCubrimientoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TiposCubrimientoService]
    });
  });

  it('should be created', inject([TiposCubrimientoService], (service: TiposCubrimientoService) => {
    expect(service).toBeTruthy();
  }));
});
