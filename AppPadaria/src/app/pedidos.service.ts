import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pedido } from './Pedido';

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
export class PedidosService {
  // url da api
  apiUrl = 'http://localhost:5000/Pedido';

  // construtor que injeta a dependência do serviço HttpClient
  constructor(private http: HttpClient) { }

  // método para obter a lista de pedidos da api
  listar(): Observable<Pedido[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Pedido[]>(url);
  }

  // método para buscar os pedidos na api
  buscar(id: number): Observable<Pedido> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Pedido>(url);
  }

  // método para cadastrar um novo pedido na api
  cadastrar(pedido: Pedido): Observable<Pedido> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Pedido>(url, pedido);
  }

  // método para atualizar um pedido existente da api
  atualizar(id: number, novoPedido: Pedido): Observable<any> {
    const url = `${this.apiUrl}/atualizar/${id}`;
    return this.http.put(url, novoPedido);
  }

  // método para excluir um pedido existente da api
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete(url);
  }
}
