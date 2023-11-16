import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doce } from './Doce';
const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type' : 'application/json'
    })
}
@Injectable({
  providedIn: 'root'
})
export class DocesService {
  apiUrl = 'http://localhost:5000/Doce';
  constructor(private http: HttpClient) { }
  listar(): Observable<Doce[]> {  
  const url = `${this.apiUrl}/listar`;
  return this.http.get<Doce[]>(url);
  }
  buscar(nomedoce: string): Observable<Doce> {
    const url = `${this.apiUrl}/buscar/${nomedoce}`;
    return this.http.get<Doce>(url);
  }
  cadastrar(doce: Doce): Observable<Doce> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Doce>(url, doce, httpOptions);
  }
  atualizar(nomedoce: string, novoDoce: Doce): Observable<any> {
    const url = `${this.apiUrl}/atualizar/${nomedoce}`;
    return this.http.put(url, novoDoce);
  }
}
