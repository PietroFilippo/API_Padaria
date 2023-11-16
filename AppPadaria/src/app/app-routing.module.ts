import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DocesComponent } from'./components/doces/doces.component';
import { SalgadosComponent } from './components/salgados/salgados.component';
import { PedidosComponent } from './components/pedidos/pedidos.component';
import { ClientesComponent } from './components/clientes/clientes.component';

const routes: Routes = [
  { path: 'doces', component: DocesComponent },
  { path: 'salgados', component: SalgadosComponent },
  { path: 'pedidos', component: PedidosComponent },
  { path: 'clientes', component: ClientesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
