import { Component, OnInit, Input } from 'angular2/core';
import { RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';
import { HTTP_PROVIDERS } from 'angular2/http';

import { Partner } from '../models/partner';
import { PartnerService } from '../services/partner.service';

@Component({
    selector: 'partner-editor',
    templateUrl: '/app/templates/components/partner-editor.html',
    providers: [PartnerService, HTTP_PROVIDERS]
})
export class PartnerEditor implements OnInit {
    public thisPartner: Partner = new Partner();

    constructor(
                private _service: PartnerService,
                private _routeParams: RouteParams,
                private _router: Router
    ) { }

    ngOnInit() {
        if (!this.thisPartner.Id) {
            let id = +this._routeParams.get("id");

            this._service.getPartner(id)
                .subscribe((partner: Partner) => this.thisPartner = partner);
        }
    }

    public save(partner: Partner) {
        console.info("About to call service to save the partner");

        this._service.update(partner).subscribe(partner => {
                console.info(partner);
                this._router.navigate(['Partners']);
            },
            error => console.error(error));
    }

    goBack() {
        window.history.back();
    }
}