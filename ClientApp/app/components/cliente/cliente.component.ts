import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../Services/cliente.service';
import { ICliente } from '../../Models/cliente.interface';

@Component({
    selector: 'app-cliente',
    templateUrl: './cliente.component.html'
})
export class ClienteComponent implements OnInit {

    clientes: ICliente[] = [];

    constructor(private clienteService: ClienteService) { }

    private getCliente() {
        this.clienteService.getClientes().subscribe(
            data => this.clientes = data,
            error => alert(error),
            () => console.log(this.clientes)
        )
    }

    ngOnInit() {
        this.getCliente();
    }
}
