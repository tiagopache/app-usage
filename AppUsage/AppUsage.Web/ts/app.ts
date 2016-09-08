import { Component } from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';

import { PartnerListComponent } from './components/partner.list';
import { PartnerEditor } from './components/partner.editor';
import { PartnerService } from './services/partner.service';

@Component({
    selector: "app-usage",
    templateUrl: "/app/templates/app.template.html",
    directives: [ROUTER_DIRECTIVES],
    providers: [
        PartnerService,
        ROUTER_PROVIDERS
    ]
})
@RouteConfig([
        { path: "/partners", name: "Partners", component: PartnerListComponent, useAsDefault: true },
        { path: "/partners/:id", name: "PartnerEditor", component: PartnerEditor }
])
export class AppComponent { }