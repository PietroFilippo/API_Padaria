import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doce } from './Doce';

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
export class DocesService {
  // url da api
  apiUrl = 'http://localhost:5000/Doce';

  // construtor que injeta a dependência do serviço HttpClient
  constructor(private http: HttpClient) { }

  // método para obter a lista de doces da api
  listar(): Observable<Doce[]> {  
  const url = `${this.apiUrl}/listar`;
  return this.http.get<Doce[]>(url);
  }

  // método para buscar um doce existente da api
  buscar(nomedoce: string): Observable<Doce> {
    const url = `${this.apiUrl}/buscar/${nomedoce}`;
    return this.http.get<Doce>(url);
  }

  // método para cadastrar um doce na api
  cadastrar(doce: Doce): Observable<Doce> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Doce>(url, doce, httpOptions);
  }
  // método para atualizar um doce da api
  atualizar(nomedoce: string, novoDoce: Doce): Observable<any> {
    const url = `${this.apiUrl}/atualizar/${nomedoce}`;
    return this.http.put(url, novoDoce);
  }
}
