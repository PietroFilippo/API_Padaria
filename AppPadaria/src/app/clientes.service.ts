import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from './Cliente';

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
export class ClientesService {
  // url da api
  apiUrl = 'http://localhost:5000/Cliente';

  // construtor que injeta a dependência do serviço HttpClient
  constructor(private http: HttpClient) { }

  // método para listar os clientes da api
  listar(): Observable<Cliente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Cliente[]>(url);
  }

  // método para buscar os clientes existentes da api
  buscar(id: number): Observable<Cliente> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Cliente>(url);
  }
  // método para cadastrar  um novo cliente na api
  cadastrar(cliente: Cliente): Observable<Cliente> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Cliente>(url, cliente);
  }
  // método para atualizar um cliente existente da api
  atualizar(id: number, novoCliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/atualizar/${id}`;
    return this.http.put(url, novoCliente);
  }

  // método para excluir um cliente da api
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete(url);
  }
}
