"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SWCharacter = /** @class */ (function () {
    function SWCharacter(name, hair_color) {
        this.name = name;
        this.hair_color = hair_color;
    }
    SWCharacter.prototype.description = function () {
        return this.name + ", with hair color " + this.hair_color;
    };
    return SWCharacter;
}());
exports.SWCharacter = SWCharacter;
