import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DocesService } from 'src/app/doces.service';
import { Doce } from 'src/app/Doce';

@Component({
  // incorporar este componente em outros componentes ou templates
  selector: 'app-doces',
  // caminho do template html 
  templateUrl: './doces.component.html',
  // estilos especificos para esse componente
  styleUrls: ['./doces.component.css']
})

// definição da classe do componente
export class DocesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  // injeção do service no construtor
  constructor(private docesService : DocesService) { }
  // método chamado quando o componente é inicializado
  ngOnInit(): void {
    // configuração inicial do formulário e do título
    this.tituloFormulario = ' Novo Doce ';
    this.formulario = new FormGroup({
      nomedoce: new FormControl(null),
      preçodoce: new FormControl(null)
    })
  }
  // método chamado quando o formulário é enviado
  enviarFormulario(): void {
    // obtenção dos valores
    const doce : Doce = this.formulario.value;
    // chamada do serviço para cadastrar o salgado
    this.docesService.cadastrar(doce).subscribe(result => {
       alert('Doce inserido com sucesso')
    })
  }
}
