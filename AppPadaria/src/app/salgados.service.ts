import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Salgado } from './Salgado';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class SalgadosService {
  apiUrl = 'http://localhost:5000/Salgado';
  constructor(private http: HttpClient) { }
  listar(): Observable<Salgado[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Salgado[]>(url);
  }
  buscar(nomesalgado: string): Observable<Salgado> {
    const url = `${this.apiUrl}/buscar/${nomesalgado}`;
    return this.http.get<Salgado>(url);
  }
  cadastrar(salgado: Salgado): Observable<Salgado> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Salgado>(url, salgado);
  }
  atualizar(nomesalgado: string, novoSalgado: Salgado): Observable<any> {
    const url = `${this.apiUrl}/atualizar/${nomesalgado}`;
    return this.http.put(url, novoSalgado);
  }
}
