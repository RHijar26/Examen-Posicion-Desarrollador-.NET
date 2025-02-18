import { Component, inject } from '@angular/core';
import { CarritoService } from '../../Services/Carrito/carrito.service';
import { Carrito } from '../../Models/Carrito/Carrito';
import { Producto } from '../../Models/Productos/Producto';

@Component({
  selector: 'app-carrito',
  standalone: false,
  templateUrl: './carrito.component.html',
  styleUrl: './carrito.component.css',
  providers: [CarritoService]
})
export class CarritoComponent {

  products: Carrito[] = []
  carrito = inject(CarritoService);
  totalPrice: number = 0;
  constructor() { }



  ngOnInit() {
    this.products = this.carrito.getShoppingCart();
    this.totalPrice = this.products.reduce((sum, product) => sum + product.Producto.Price, 0);
  }

  removeProduct(product: Producto) {
    console.log('removing product');
    this.carrito.removeProduct(product);
    this.products = this.carrito.getShoppingCart();
  }

  addAmount(product: Carrito) {
    product.Cantidad = product.Cantidad + 1;
    this.carrito.update(product.Producto, product.Cantidad);
  }

  removeAmount(product: Carrito) {
    if (product.Cantidad > 1) {
      product.Cantidad = product.Cantidad - 1;
      this.carrito.update(product.Producto, product.Cantidad);
    }

  }

}
