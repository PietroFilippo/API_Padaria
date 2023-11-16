import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

// serviço para manipular os dados relacionados as models da api

import { DocesService } from './doces.service';
import { DocesComponent } from './components/doces/doces.component';

import { SalgadosService } from './salgados.service';
import { SalgadosComponent } from './components/salgados/salgados.component';

import { PedidosService } from './pedidos.service';
import { PedidosComponent } from './components/pedidos/pedidos.component';

import { ClientesService } from './clientes.service';
import { ClientesComponent } from './components/clientes/clientes.component';

@NgModule({
  // declaração dos componentes que pertencem a este módulo
  declarations: [
    AppComponent,
    DocesComponent,
    SalgadosComponent,
    PedidosComponent,
    ClientesComponent
  ],
  // importação de módulos necessários 
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  // serviços disponíveis para a injeção de dependência
  providers: [HttpClientModule, DocesService, SalgadosService, PedidosService, ClientesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
