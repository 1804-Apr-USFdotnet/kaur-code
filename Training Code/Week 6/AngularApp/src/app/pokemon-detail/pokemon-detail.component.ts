import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pokemon } from '../models/pokemon';
import { PokemonService } from '../pokemon.service';

@Component({
  selector: 'app-pokemon-detail',
  templateUrl: './pokemon-detail.component.html',
  styleUrls: ['./pokemon-detail.component.css']
})
export class PokemonDetailComponent implements OnInit {
  poke: Pokemon;

  constructor(
    private route: ActivatedRoute,    // needed to check route parameter
    private pokeSvc: PokemonService
  ) { }

  ngOnInit() {
    var name = this.route.snapshot.paramMap.get("name"); // get "name" parameter value
    this.pokeSvc.getPokemonByName(name, (response) => {
      this.poke = response;
    });
  }

}
