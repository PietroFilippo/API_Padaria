import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pedido } from './Pedido'; 
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class PedidosService {
  apiUrl = 'http://localhost:5000/Pedido';
  constructor(private http: HttpClient) { }
  listar(): Observable<Pedido[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Pedido[]>(url);
  }
  buscar(id: number): Observable<Pedido> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Pedido>(url);
  }
  cadastrar(pedido: Pedido): Observable<Pedido> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Pedido>(url, pedido);
  }
  atualizar(id: number, novoPedido: Pedido): Observable<any> {
    const url = `${this.apiUrl}/atualizar/${id}`;
    return this.http.put(url, novoPedido);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete(url);
  }
}
