import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// importação dos componentes que estão associados as rotas
import { DocesComponent } from'./components/doces/doces.component';
import { SalgadosComponent } from './components/salgados/salgados.component';
import { PedidosComponent } from './components/pedidos/pedidos.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { BebidasComponent } from './components/bebidas/bebidas.component';
import { CriarBebidaComponent } from './components/criar-bebida/criar-bebida.component';


// definição das rotas da aplicação
const routes: Routes = [
  { path: 'doces', component: DocesComponent },
  { path: 'salgados', component: SalgadosComponent },
  { path: 'pedidos', component: PedidosComponent },
  { path: 'clientes', component: ClientesComponent },
  { path: 'bebidas', component: BebidasComponent },
  { path: 'criar-bebida', component: CriarBebidaComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
