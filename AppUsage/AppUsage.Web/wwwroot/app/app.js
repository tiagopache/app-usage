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
var partner_list_1 = require('./components/partner.list');
var partner_editor_1 = require('./components/partner.editor');
var partner_service_1 = require('./services/partner.service');
var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: "app-usage",
            templateUrl: "/app/templates/app.template.html",
            directives: [router_1.ROUTER_DIRECTIVES],
            providers: [
                partner_service_1.PartnerService,
                router_1.ROUTER_PROVIDERS
            ]
        }),
        router_1.RouteConfig([
            { path: "/partners", name: "Partners", component: partner_list_1.PartnerListComponent, useAsDefault: true },
            { path: "/partners/:id", name: "PartnerEditor", component: partner_editor_1.PartnerEditor }
        ]), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.js.map