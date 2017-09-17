import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
//import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
//import { CounterComponent } from './components/counter/counter.component';
import { ClienteComponent } from './components/cliente/cliente.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        //CounterComponent,
        //FetchDataComponent,
        HomeComponent,
        ClienteComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'cliente', component: ClienteComponent },
            //{ path: 'counter', component: CounterComponent },
            //{ path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
