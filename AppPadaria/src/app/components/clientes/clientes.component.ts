import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClientesService } from 'src/app/clientes.service';
import { Cliente } from 'src/app/Cliente';

@Component({
  // incorporar este componente em outros componentes ou templates
  selector: 'app-clientes',
  // caminho do template html 
  templateUrl: './clientes.component.html',
  // estilos especificos para esse componente
  styleUrls: ['./clientes.component.css']
})

// definição da classe do componente
export class ClientesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  // injeção do service no construtor
  constructor(private clientesService: ClientesService) { }
  // método chamado quando o componente é inicializado
  ngOnInit(): void {
    // configuração inicial do formulário e do título
    this.tituloFormulario = ' Novo Cliente ';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      endereco: new FormControl(null),
      telefone: new FormControl(null)
    })
  }
  // método chamado quando o formulário é enviado
  enviarFormulario(): void {
    // obtenção dos valores
    const cliente: Cliente = this.formulario.value;
    // chamada do serviço para cadastrar o salgado
    this.clientesService.cadastrar(cliente).subscribe(result => {
      alert('Cliente inserido com sucesso')
    })
  }
}
