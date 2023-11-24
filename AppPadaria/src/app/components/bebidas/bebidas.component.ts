// bebida.component.ts

import { Component, OnInit } from '@angular/core';
import { BebidasService } from './../../bebidas.service';

@Component({
  selector: 'app-bebidas',
  templateUrl: './bebidas.component.html',
  styleUrls: ['./bebidas.component.css']
})
export class BebidasComponent implements OnInit {
  bebidas: any[] = [];
  selectedBebida: any;

  constructor(private bebidasService: BebidasService) { }

  ngOnInit(): void {
    this.bebidasService.listarBebidas().subscribe(data => {
      this.bebidas = data;
    });
  }
}
