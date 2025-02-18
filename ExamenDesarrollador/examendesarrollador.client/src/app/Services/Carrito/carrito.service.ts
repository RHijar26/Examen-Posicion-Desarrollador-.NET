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
    const productsData = localStorage.getItem('products');
    if (productsData)
    {
      this.listaProductos = JSON.parse(productsData);
    }

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
      this.listaProductos[productoExiste].Cantidad += cantidad;
    }

    this.cartSubject.next(this.listaProductos); // Emit updated cart

    localStorage.setItem('products', JSON.stringify(this.listaProductos));
  }

  removeProduct(product: Producto)
  {
    const index = this.listaProductos.findIndex(p => p.Producto.Id == product.Id);    

    if (index != -1)
    {
      this.listaProductos.splice(index, 1);
      localStorage.setItem('products', JSON.stringify(this.listaProductos));
    }
  }

  update(product: Producto, amount: number) {
    const index = this.listaProductos.findIndex(p => p.Producto.Id == product.Id);

    if (index != -1 && index < this.listaProductos.length) {
      this.listaProductos[index].Cantidad = amount;
      localStorage.setItem('products', JSON.stringify(this.listaProductos));
    }
  }
}
