import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SalgadosService } from 'src/app/salgados.service';
import { Salgado } from 'src/app/Salgado';

@Component({
  selector: 'app-salgados',
  templateUrl: './salgados.component.html',
  styleUrls: ['./salgados.component.css']
})

export class SalgadosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  constructor(private salgadosService: SalgadosService) { }
  ngOnInit(): void {
    this.tituloFormulario = ' Novo Salgado ';
    this.formulario = new FormGroup({
      nomesalgado: new FormControl(null),
      preçosalgado: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const salgado: Salgado = this.formulario.value;
    this.salgadosService.cadastrar(salgado).subscribe(result => {
      alert('Salgado inserido com sucesso')
    })
  }
}
