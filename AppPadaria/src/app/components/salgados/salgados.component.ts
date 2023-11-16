import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SalgadosService } from 'src/app/salgados.service';
import { Salgado } from 'src/app/Salgado';

@Component({
  // incorporar este componente em outros componentes ou templates
  selector: 'app-salgados',
  // caminho do template html 
  templateUrl: './salgados.component.html',
  // estilos especificos para esse componente
  styleUrls: ['./salgados.component.css']
})

// definição da classe do componente
export class SalgadosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  // injeção do service no construtor
  constructor(private salgadosService: SalgadosService) { }
  // método chamado quando o componente é inicializado
  ngOnInit(): void {
    // configuração inicial do formulário e do título
    this.tituloFormulario = ' Novo Salgado ';
    this.formulario = new FormGroup({
      nomesalgado: new FormControl(null),
      preçosalgado: new FormControl(null)
    })
  }
  // método chamado quando o formulário é enviado
  enviarFormulario(): void {
    // obtenção dos valores
    const salgado: Salgado = this.formulario.value;
    // chamada do serviço para cadastrar o salgado
    this.salgadosService.cadastrar(salgado).subscribe(result => {
      alert('Salgado inserido com sucesso')
    })
  }
}
