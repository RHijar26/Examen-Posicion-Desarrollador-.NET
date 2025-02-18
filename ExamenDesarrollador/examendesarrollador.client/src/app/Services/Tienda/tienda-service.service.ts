import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../Enviroments/enviroments';
import { Tienda } from '../../Models/Tienda/Tienda';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TiendaService {
  private apiUrl = environment.apiUrl + 'shop/';

  constructor(private http: HttpClient) { }


  saveShop(shop: Tienda): Observable<Tienda> {

    if (shop.Id != 0) {
      return this.http.put<Tienda>(this.apiUrl, shop);
    } else {
      return this.http.post<Tienda>(this.apiUrl, shop);
    }

  }
  getShops(): Observable<Tienda[]> {
    return this.http.get<Tienda[]>(this.apiUrl);
  }

  removeShop(shopId: number) {
    return this.http.delete<boolean>(`${this.apiUrl}${shopId}`);
  }

}
