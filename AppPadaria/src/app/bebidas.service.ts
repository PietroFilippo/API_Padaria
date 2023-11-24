import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BebidasService {
  private apiUrl = 'http://localhost:5000/';

  constructor(private http: HttpClient) { }

  listarBebidas(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}Bebida/listar`);
  }
  criarBebida(novaBebida: any): Observable<any[]> {
    return this.http.post<any[]>(`${this.apiUrl}Bebida/cadastrar`, novaBebida);
  }
}
