import { Component, OnInit } from '@angular/core';
import { Pokemon } from '../models/pokemon';
import { PokemonService } from '../pokemon.service';

@Component({
  selector: 'app-pokemon',
  templateUrl: './pokemon.component.html',
  styleUrls: ['./pokemon.component.css']
})
export class PokemonComponent implements OnInit {

  pokemons: Pokemon[] = [
    {name: "Darth Vader", height: 70, weight: 200}
  ];

  searchText: string;

  constructor(private pokeSvc: PokemonService) { }

  ngOnInit() {
  }

  searchPokemon() {
    this.pokeSvc.getPokemon(this.searchText, (response) => {
      this.pokemons = response.results;
    });
  }

}
