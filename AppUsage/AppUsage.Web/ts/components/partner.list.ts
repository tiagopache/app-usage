import { Component, OnInit } from 'angular2/core';
import { RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';
import { HTTP_PROVIDERS } from 'angular2/http';

import { Partner } from '../models/partner';
import { PartnerService } from '../services/partner.service';

@Component({
    selector: "partner-list",
    templateUrl: "/app/templates/components/partner-list.html",
    providers: [PartnerService, HTTP_PROVIDERS],
    directives: [ROUTER_DIRECTIVES]
})
export class PartnerListComponent implements OnInit {

    public selectedPartner: Partner;

    public Partners: Partner[] = [
        { Id: 1, Name: "Partner 1", Devices: null, Programs: null },
        { Id: 2, Name: "Partner 2", Devices: null, Programs: null },
        { Id: 3, Name: "Partner 3", Devices: null, Programs: null }
    ];

    constructor(
        private _partnerService: PartnerService,
        private _router: Router
    ) { }

    ngOnInit() {
        this._partnerService.getPartners()
            .subscribe(
                foundPartners => this.Partners = foundPartners,
                error => console.error(error)
            ); 
    }

    selectPartner(partner: Partner) {
        this.selectedPartner = partner;
    }

    delete(removePartner: Partner) {
        if (confirm(`Are you sure you want to delete the ${removePartner.Name}?`)) {
            console.log(`Deleting the ${removePartner.Name}`);

            this._partnerService.delete(removePartner.Id)
                .subscribe(
                partner => {
                    console.log("Completed deletion");
                },
                error => console.error(error)
            );

            this._router.navigate(['Partners']);
        }
    }
}
