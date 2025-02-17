import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Producto } from '../../Models/Productos/Producto';
import { environment } from '../../../Enviroments/enviroments';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private apiUrl = environment.apiUrl + 'product/';

  constructor(private http: HttpClient) { }

  saveProduct(product: Producto): Observable<Producto> {

    if (product.Id != 0) {
      return this.http.put<Producto>(this.apiUrl, product);
    } else {
      return this.http.post<Producto>(this.apiUrl, product);
    }

  }
  getProduct(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.apiUrl);
  }

  removeProduct(productId: number) {
    return this.http.delete<boolean>(`${this.apiUrl}${productId}`);
  }
}
