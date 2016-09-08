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
var partner_service_1 = require('../services/partner.service');
var PartnerListComponent = (function () {
    function PartnerListComponent(_partnerService, _router) {
        this._partnerService = _partnerService;
        this._router = _router;
        this.Partners = [
            { Id: 1, Name: "Partner 1", Devices: null, Programs: null },
            { Id: 2, Name: "Partner 2", Devices: null, Programs: null },
            { Id: 3, Name: "Partner 3", Devices: null, Programs: null }
        ];
    }
    PartnerListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._partnerService.getPartners()
            .subscribe(function (foundPartners) { return _this.Partners = foundPartners; }, function (error) { return console.error(error); });
    };
    PartnerListComponent.prototype.selectPartner = function (partner) {
        this.selectedPartner = partner;
    };
    PartnerListComponent.prototype.delete = function (removePartner) {
        if (confirm("Are you sure you want to delete the " + removePartner.Name + "?")) {
            console.log("Deleting the " + removePartner.Name);
            this._partnerService.delete(removePartner.Id)
                .subscribe(function (partner) {
                console.log("Completed deletion");
            }, function (error) { return console.error(error); });
            this._router.navigate(['Partners']);
        }
    };
    PartnerListComponent = __decorate([
        core_1.Component({
            selector: "partner-list",
            templateUrl: "/app/templates/components/partner-list.html",
            providers: [partner_service_1.PartnerService, http_1.HTTP_PROVIDERS],
            directives: [router_1.ROUTER_DIRECTIVES]
        }), 
        __metadata('design:paramtypes', [partner_service_1.PartnerService, router_1.Router])
    ], PartnerListComponent);
    return PartnerListComponent;
}());
exports.PartnerListComponent = PartnerListComponent;
//# sourceMappingURL=partner.list.js.map