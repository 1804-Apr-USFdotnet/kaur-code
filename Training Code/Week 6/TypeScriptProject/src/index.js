"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ajax_1 = require("./ajax");
var swcharacter_1 = require("./swcharacter");
function addCharacter(character) {
    var el = document.querySelector("#btnList");
    var newEl = document.createElement("li");
    newEl.innerText = character.description();
    el.appendChild(newEl);
}
function updateResultsList(responseText) {
    var searchList = document.querySelector("#searchList");
    searchList.innerHTML = ""; // clear the list
    var response = JSON.parse(responseText);
    for (var i = 0; i < response.results.length; i++) {
        var newEl = document.createElement("li");
        var item = response.results[i];
        var char = new swcharacter_1.SWCharacter(item.name, item.hair_color);
        newEl.innerText = char.description();
        searchList.appendChild(newEl);
    }
}
function main() {
    var ajax = new ajax_1.Ajax();
    var btn = document.querySelector("#btn");
    if (btn !== null) {
        btn.addEventListener('click', function () {
            ajax.send("https://swapi.co/api/people/1", "get", function (text) {
                var response = JSON.parse(text);
                var char = new swcharacter_1.SWCharacter(response.name, response.hair_color);
                addCharacter(char);
            });
        });
    }
    var searchBtn = document.querySelector("#searchBtn");
    if (searchBtn !== null) {
        searchBtn.addEventListener('click', function () {
            var searchTextField = document.querySelector("#searchText");
            var searchText = searchTextField.value;
            ajax.send("https://swapi.co/api/people/?search=" + searchText, "get", updateResultsList);
        });
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
