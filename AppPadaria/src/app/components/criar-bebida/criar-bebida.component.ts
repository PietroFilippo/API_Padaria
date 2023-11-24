import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BebidasService } from 'src/app/bebidas.service';


@Component({
  selector: 'app-criar-bebida',
  templateUrl: './criar-bebida.component.html',
  styleUrls: ['./criar-bebida.component.css']
})
export class CriarBebidaComponent {
  bebida = {
    nomeBebida: '',
    precoBebida: 0
  };

  constructor(private router: Router, private bebidasService: BebidasService) {}


  criarBebida() {
    console.log(this.bebida);
    this.bebidasService.criarBebida(this.bebida).subscribe(([]) => {
    });
    
  }
}
