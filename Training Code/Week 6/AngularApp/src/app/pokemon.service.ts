import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  constructor(private httpClient: HttpClient) { }

  getPokemon(searchText: string, onSuccess) {
    var url = "https://pokeapi.co/api/v2/pokemon/?search=" + searchText;
    var req = this.httpClient.get(url);
    var promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    );
  }
}
