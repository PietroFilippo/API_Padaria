import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PedidosService } from 'src/app/pedidos.service';
import { Pedido } from 'src/app/Pedido';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})

export class PedidosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  constructor(private pedidosService: PedidosService) { }
  ngOnInit(): void {
    this.tituloFormulario = ' Novo Pedido ';
    this.formulario = new FormGroup({
      nomePedido: new FormControl(null),
      dataPedido: new FormControl(null),
      status: new FormControl(null),
      clienteId: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const pedido: Pedido = this.formulario.value;
    this.pedidosService.cadastrar(pedido).subscribe(result => {
      alert('Pedido inserido com sucesso')
    })
  }
}
