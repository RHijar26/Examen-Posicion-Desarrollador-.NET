import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../Enviroments/enviroments';
import { Cliente } from '../../Models/Clientes/Cliente';
import { Observable } from 'rxjs';
import { Producto } from '../../Models/Productos/Producto';
import { Carrito } from '../../Models/Carrito/Carrito';

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

  registerBuy(cart: Carrito[]) {
    const token = localStorage.getItem('token'); // Retrieve token from localStorage

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}` // Set the token in the header
    });

    return this.http.post<boolean>(`${this.apiUrl}RegisterBuy`, cart, { headers });
  }

}
