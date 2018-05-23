"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Ajax = /** @class */ (function () {
    function Ajax() {
        this.xhr = new XMLHttpRequest();
    }
    Ajax.prototype.send = function (url, method, success, fail) {
        var _this = this;
        if (method === void 0) { method = "get"; }
        if (fail === void 0) { fail = function (error) { console.log(error); }; }
        this.xhr = new XMLHttpRequest();
        this.xhr.addEventListener("load", function () {
            if (_this.xhr.status === 200) {
                success(_this.xhr.responseText);
            }
            else {
                fail(_this.xhr.statusText);
            }
        });
        this.xhr.open(method, url);
        this.xhr.send();
    };
    return Ajax;
}());
exports.Ajax = Ajax;
