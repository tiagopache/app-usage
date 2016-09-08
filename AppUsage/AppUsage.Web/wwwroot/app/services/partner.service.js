"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var http_1 = require('angular2/http');
var Observable_1 = require('rxjs/Observable');
require('rxjs/Rx');
require('rxjs/add/operator/map');
var PartnerService = (function () {
    function PartnerService(_http) {
        this._http = _http;
        this._partnerUrl = "http://localhost:10472/api/Partner";
    }
    PartnerService.prototype.getPartners = function () {
        var data = this._http.get(this._partnerUrl)
            .map(function (res) { return res.json(); });
        return data;
    };
    PartnerService.prototype.getPartner = function (id) {
        var data = this._http.get(this._partnerUrl + '/' + id)
            .map(function (res) { return res.json(); });
        return data;
    };
    PartnerService.prototype.update = function (partner) {
        var body = JSON.stringify(partner);
        var headers = new http_1.Headers({ "Content-Type": "application/json" });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.put(this._partnerUrl + "/" + partner.Id, body, options)
            .catch(this.handleError);
    };
    PartnerService.prototype.delete = function (id) {
        return this._http.delete(this._partnerUrl + "/" + id)
            .catch(this.handleError);
    };
    PartnerService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server.error');
    };
    PartnerService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], PartnerService);
    return PartnerService;
}());
exports.PartnerService = PartnerService;
//# sourceMappingURL=partner.service.js.map