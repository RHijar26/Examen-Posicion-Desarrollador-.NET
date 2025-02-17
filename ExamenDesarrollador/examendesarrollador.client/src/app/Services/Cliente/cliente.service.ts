import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../Enviroments/enviroments';
import { Cliente } from '../../Models/Clientes/Cliente';
import { Observable } from 'rxjs';
import { Producto } from '../../Models/Productos/Producto';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private apiUrl = environment.apiUrl + 'client/';

  constructor(private http: HttpClient) { }

  saveClient(client: Cliente): Observable<Cliente> {
    if (client.Id != 0) {
      return this.http.put<Cliente>(this.apiUrl, client);
    } else {
      return this.http.post<Cliente>(this.apiUrl, client);
    }
  }

  getClients(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }

  removeClient(clientId: number) {
    return this.http.delete<boolean>(`${this.apiUrl}${clientId}`);
  }

}
