import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PedidosService } from 'src/app/pedidos.service';
import { Pedido } from 'src/app/Pedido';

@Component({
  // incorporar este componente em outros componentes ou templates
  selector: 'app-pedidos',
  // caminho do template html 
  templateUrl: './pedidos.component.html',
  // estilos especificos para esse componente
  styleUrls: ['./pedidos.component.css']
})

// definição da classe do componente
export class PedidosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  // injeção do service no construtor
  constructor(private pedidosService: PedidosService) { }
  // método chamado quando o componente é inicializado
  ngOnInit(): void {
    // configuração inicial do formulário e do título
    this.tituloFormulario = ' Novo Pedido ';
    this.formulario = new FormGroup({
      nomePedido: new FormControl(null),
      dataPedido: new FormControl(null),
      status: new FormControl(null),
      clienteId: new FormControl(null)
    })
  }
  // método chamado quando o formulário é enviado
  enviarFormulario(): void {
    // obtenção dos valores
    const pedido: Pedido = this.formulario.value;
    // chamada do serviço para cadastrar o salgado
    this.pedidosService.cadastrar(pedido).subscribe(result => {
      alert('Pedido inserido com sucesso')
    })
  }
}
