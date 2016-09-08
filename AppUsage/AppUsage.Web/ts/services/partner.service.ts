import { Injectable } from 'angular2/core';
import { Http, Response, Headers, RequestOptions } from 'angular2/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import 'rxjs/add/operator/map';

import { Partner } from '../models/partner';

@Injectable()
export class PartnerService {
    constructor(private _http: Http) { }

    private _partnerUrl: string = "http://localhost:10472/api/Partner";

    getPartners(): Observable<Partner[]> {
        let data: Observable<Partner[]> = this._http.get(this._partnerUrl)
            .map(res => <Partner[]>res.json());

        return data;
    }

    getPartner(id: number): Observable<Partner> {
        let data: Observable<Partner> = this._http.get(this._partnerUrl + '/' + id)
            .map(res => <Partner>res.json());

        return data;
    }

    update(partner: Partner): Observable<Partner> {
        let body = JSON.stringify(partner);
        let headers = new Headers({ "Content-Type": "application/json" });
        let options = new RequestOptions({ headers: headers });

        return this._http.put(this._partnerUrl + "/" + partner.Id, body, options)
            .catch(this.handleError);
    }

    delete(id: number): Observable<Partner> {
        return this._http.delete(this._partnerUrl + "/" + id)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server.error');
    }
}