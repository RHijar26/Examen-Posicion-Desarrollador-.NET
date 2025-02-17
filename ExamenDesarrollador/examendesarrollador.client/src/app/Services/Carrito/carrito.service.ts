import { Injectable } from '@angular/core';
import { Producto } from '../../Models/Productos/Producto';
import { Carrito } from '../../Models/Carrito/Carrito';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarritoService {

  private listaProductos: Carrito[] = [];
  private cartSubject = new BehaviorSubject<Carrito[]>([]);

  cart$ = this.cartSubject.asObservable(); // Observable for cart updates
  constructor() { }

  getShoppingCart()
  {
    return this.listaProductos;
  }


  add(producto: Producto, cantidad: number = 1)
  {
    const productoExiste = this.listaProductos.findIndex(item => producto.Id == item.Producto.Id);

    if (productoExiste == -1) {

      var carritoItem = new Carrito(producto, cantidad);
      this.listaProductos.push(carritoItem);
    }
    else
    {
      this.listaProductos[productoExiste].Cantidad = cantidad;
    }

    this.cartSubject.next(this.listaProductos); // Emit updated cart
  }
}
