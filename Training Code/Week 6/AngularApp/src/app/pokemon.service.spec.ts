import { TestBed, inject } from '@angular/core/testing';

import { PokemonService } from './pokemon.service';
import { HttpClientModule } from '@angular/common/http';

describe('PokemonService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PokemonService],
      imports: [HttpClientModule]
    });
  });

  it('should be created', inject([PokemonService], (service: PokemonService) => {
    expect(service).toBeTruthy();
  }));

  it('should find ivysaur', inject([PokemonService], (service: PokemonService) => {
    service.getPokemonByName("ivysaur", (response) => {
      expect(response.name).toBe("ivysaur");
    },
    fail);
  }));
});
