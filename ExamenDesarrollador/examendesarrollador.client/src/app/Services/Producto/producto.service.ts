import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Producto } from '../../Models/Productos/Producto';
import { environment } from '../../../Enviroments/enviroments';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private apiUrl = environment.apiUrl + 'product';

  constructor(private http: HttpClient) { }

  guardarProducto(product: Producto): Observable<Producto> {

    if (product.Id != 0) {
      return this.http.put<Producto>(this.apiUrl, product);
    } else {
      return this.http.post<Producto>(this.apiUrl, product);
    }

  }

  obtenerProductos(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.apiUrl);
  }
}
