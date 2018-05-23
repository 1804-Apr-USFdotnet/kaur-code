import { Ajax } from "./ajax";
import { SWCharacter } from "./swcharacter";

function addCharacter(character: SWCharacter) {
    var el = document.querySelector("#btnList");
    if (el !== null) {
        var newEl = document.createElement("li");
        newEl.innerText = character.description();
        el.appendChild(newEl);
    }
}

function main() {
    var ajax = new Ajax();

    var btn = document.querySelector("#btn");
    if (btn !== null) {
        btn.addEventListener(
            'click',
            () => {
                ajax.send(
                    "https://swapi.co/api/people/1",
                    "get",
                    (text) => {
                        var response = JSON.parse(text);
                        var char: SWCharacter = new SWCharacter(response.name, response.hair_color);
                        addCharacter(char);
                    }
                );
            }
        );
    }
}

main();


// function addItem() {
//     var el = document.querySelector("#btnList");
//     if (el !== null) {
//         var newEl = document.createElement("li");
//         newEl.innerText = "item";
//         el.appendChild(newEl);
//     }
// }

// var number = 1;

// function getPokemon() {
//     // AJAX: asynchronous JavaScript and XMLHttpRequest
//     var xhr = new XMLHttpRequest();
//     xhr.addEventListener("load", function () {
//         var response = JSON.parse(this.responseText);
//         addPokemon(response);
//     });
//     xhr.open("get", "https://swapi.co/api/people/" + number);
//     xhr.send();
//     number += 1;
// }

// function addPokemon(pokemon: any) {
//     var el = document.querySelector("#btnList");
//     if (el !== null) {
//         var newEl = document.createElement("li");
//         newEl.innerText = pokemon.name;
//         el.appendChild(newEl);
//     }
// }

// var btn = document.querySelector("#btn");
// if (btn !== null) {
//     btn.addEventListener('click', getPokemon);
// }
