import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  constructor(private httpClient: HttpClient) { }

  getPokemon(
    searchText: string,
    onSuccess,
    onFail = (reason) => console.log(reason)) {
    // doesn't actually work because pokeapi doesn't have search
    var url = "https://pokeapi.co/api/v2/pokemon/?search=" + searchText;
    var req = this.httpClient.get(url);
    var promise = req.toPromise();

    promise.then(
      onSuccess,
      onFail
    );
  }

  getPokemonByName(
    name: string,
    onSuccess,
    onFail = (reason) => console.log(reason)) {
    var url = "https://pokeapi.co/api/v2/pokemon/" + name;
    var req = this.httpClient.get(url);
    var promise = req.toPromise();

    promise.then(
      onSuccess,
      onFail
    );
  }
}
