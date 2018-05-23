/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/index.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/ajax.js":
/*!*********************!*\
  !*** ./src/ajax.js ***!
  \*********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
eval("\r\nObject.defineProperty(exports, \"__esModule\", { value: true });\r\nvar Ajax = /** @class */ (function () {\r\n    function Ajax() {\r\n        this.xhr = new XMLHttpRequest();\r\n    }\r\n    Ajax.prototype.send = function (url, method, success, fail) {\r\n        var _this = this;\r\n        if (method === void 0) { method = \"get\"; }\r\n        if (fail === void 0) { fail = function (error) { console.log(error); }; }\r\n        this.xhr = new XMLHttpRequest();\r\n        this.xhr.addEventListener(\"load\", function () {\r\n            if (_this.xhr.status === 200) {\r\n                success(_this.xhr.responseText);\r\n            }\r\n            else {\r\n                fail(_this.xhr.statusText);\r\n            }\r\n        });\r\n        this.xhr.open(method, url);\r\n        this.xhr.send();\r\n    };\r\n    return Ajax;\r\n}());\r\nexports.Ajax = Ajax;\r\n\n\n//# sourceURL=webpack:///./src/ajax.js?");

/***/ }),

/***/ "./src/index.js":
/*!**********************!*\
  !*** ./src/index.js ***!
  \**********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
eval("\r\nObject.defineProperty(exports, \"__esModule\", { value: true });\r\nvar ajax_1 = __webpack_require__(/*! ./ajax */ \"./src/ajax.js\");\r\nvar swcharacter_1 = __webpack_require__(/*! ./swcharacter */ \"./src/swcharacter.js\");\r\nfunction addCharacter(character) {\r\n    var el = document.querySelector(\"#btnList\");\r\n    if (el !== null) {\r\n        var newEl = document.createElement(\"li\");\r\n        newEl.innerText = character.description();\r\n        el.appendChild(newEl);\r\n    }\r\n}\r\nfunction main() {\r\n    var ajax = new ajax_1.Ajax();\r\n    var btn = document.querySelector(\"#btn\");\r\n    if (btn !== null) {\r\n        btn.addEventListener('click', function () {\r\n            ajax.send(\"https://swapi.co/api/people/1\", \"get\", function (text) {\r\n                var response = JSON.parse(text);\r\n                var char = new swcharacter_1.SWCharacter(response.name, response.hair_color);\r\n                addCharacter(char);\r\n            });\r\n        });\r\n    }\r\n}\r\nmain();\r\n// function addItem() {\r\n//     var el = document.querySelector(\"#btnList\");\r\n//     if (el !== null) {\r\n//         var newEl = document.createElement(\"li\");\r\n//         newEl.innerText = \"item\";\r\n//         el.appendChild(newEl);\r\n//     }\r\n// }\r\n// var number = 1;\r\n// function getPokemon() {\r\n//     // AJAX: asynchronous JavaScript and XMLHttpRequest\r\n//     var xhr = new XMLHttpRequest();\r\n//     xhr.addEventListener(\"load\", function () {\r\n//         var response = JSON.parse(this.responseText);\r\n//         addPokemon(response);\r\n//     });\r\n//     xhr.open(\"get\", \"https://swapi.co/api/people/\" + number);\r\n//     xhr.send();\r\n//     number += 1;\r\n// }\r\n// function addPokemon(pokemon: any) {\r\n//     var el = document.querySelector(\"#btnList\");\r\n//     if (el !== null) {\r\n//         var newEl = document.createElement(\"li\");\r\n//         newEl.innerText = pokemon.name;\r\n//         el.appendChild(newEl);\r\n//     }\r\n// }\r\n// var btn = document.querySelector(\"#btn\");\r\n// if (btn !== null) {\r\n//     btn.addEventListener('click', getPokemon);\r\n// }\r\n\n\n//# sourceURL=webpack:///./src/index.js?");

/***/ }),

/***/ "./src/swcharacter.js":
/*!****************************!*\
  !*** ./src/swcharacter.js ***!
  \****************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
eval("\r\nObject.defineProperty(exports, \"__esModule\", { value: true });\r\nvar SWCharacter = /** @class */ (function () {\r\n    function SWCharacter(name, hair_color) {\r\n        this.name = name;\r\n        this.hair_color = hair_color;\r\n    }\r\n    SWCharacter.prototype.description = function () {\r\n        return this.name + \", with hair color \" + this.hair_color;\r\n    };\r\n    return SWCharacter;\r\n}());\r\nexports.SWCharacter = SWCharacter;\r\n\n\n//# sourceURL=webpack:///./src/swcharacter.js?");

/***/ })

/******/ });