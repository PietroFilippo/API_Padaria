import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DocesService } from 'src/app/doces.service';
import { Doce } from 'src/app/Doce';

@Component({
  selector: 'app-doces',
  templateUrl: './doces.component.html',
  styleUrls: ['./doces.component.css']
})

export class DocesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  constructor(private docesService : DocesService) { }
  ngOnInit(): void {
    this.tituloFormulario = ' Novo Doce ';
    this.formulario = new FormGroup({
      nomedoce: new FormControl(null),
      preçodoce: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const doce : Doce = this.formulario.value;
    this.docesService.cadastrar(doce).subscribe(result => {
       alert('Doce inserido com sucesso')
    })
  }
}
