import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Salgado } from './Salgado';

// padrão para as requisições http
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

// indica que a classe é um serviço e pode ser injetada em outros componentes
@Injectable({
  providedIn: 'root'
})
export class SalgadosService {
  // url da api
  apiUrl = 'http://localhost:5000/Salgado';

  // construtor que injeta a dependência do serviço HttpClient
  constructor(private http: HttpClient) { }

  // método para obter a lista de salgados da api
  listar(): Observable<Salgado[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Salgado[]>(url);
  }

  // método para buscar um salgado pelo nome na api
  buscar(nomesalgado: string): Observable<Salgado> {
    const url = `${this.apiUrl}/buscar/${nomesalgado}`;
    return this.http.get<Salgado>(url);
  }

  // método para cadastrar um novo salgado na api
  cadastrar(salgado: Salgado): Observable<Salgado> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Salgado>(url, salgado);
  }

  // método para atualizar um salgado na api
  atualizar(nomesalgado: string, novoSalgado: Salgado): Observable<any> {
    const url = `${this.apiUrl}/atualizar/${nomesalgado}`;
    return this.http.put(url, novoSalgado);
  }
}
