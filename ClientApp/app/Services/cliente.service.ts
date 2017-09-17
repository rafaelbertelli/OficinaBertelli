import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { ICliente } from '../Models/cliente.interface';

@Injectable()
export class ClienteService {

    constructor(private http: Http) { }

    //get
    getClientes() {
        return this.http.get("/api/Clientes").map(data => <ICliente[]>data.json());
    }
}