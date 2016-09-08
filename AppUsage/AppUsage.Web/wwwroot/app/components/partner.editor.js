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
var router_1 = require('angular2/router');
var http_1 = require('angular2/http');
var partner_1 = require('../models/partner');
var partner_service_1 = require('../services/partner.service');
var PartnerEditor = (function () {
    function PartnerEditor(_service, _routeParams, _router) {
        this._service = _service;
        this._routeParams = _routeParams;
        this._router = _router;
        this.thisPartner = new partner_1.Partner();
    }
    PartnerEditor.prototype.ngOnInit = function () {
        var _this = this;
        if (!this.thisPartner.Id) {
            var id = +this._routeParams.get("id");
            this._service.getPartner(id)
                .subscribe(function (partner) { return _this.thisPartner = partner; });
        }
    };
    PartnerEditor.prototype.save = function (partner) {
        var _this = this;
        console.info("About to call service to save the partner");
        this._service.update(partner).subscribe(function (partner) {
            console.info(partner);
            _this._router.navigate(['Partners']);
        }, function (error) { return console.error(error); });
    };
    PartnerEditor.prototype.goBack = function () {
        window.history.back();
    };
    PartnerEditor = __decorate([
        core_1.Component({
            selector: 'partner-editor',
            templateUrl: '/app/templates/components/partner-editor.html',
            providers: [partner_service_1.PartnerService, http_1.HTTP_PROVIDERS]
        }), 
        __metadata('design:paramtypes', [partner_service_1.PartnerService, router_1.RouteParams, router_1.Router])
    ], PartnerEditor);
    return PartnerEditor;
}());
exports.PartnerEditor = PartnerEditor;
//# sourceMappingURL=partner.editor.js.map