import { Component, inject } from '@angular/core';
import { CarritoService } from '../../Services/Carrito/carrito.service';
import { Carrito } from '../../Models/Carrito/Carrito';
import { Producto } from '../../Models/Productos/Producto';
import { ClienteService } from '../../Services/Cliente/cliente.service';
import { ToastrService } from 'ngx-toastr';

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
  constructor(private clientService: ClienteService, private toastr: ToastrService) { }



  ngOnInit() {
    this.products = this.carrito.getShoppingCart();
    this.totalPrice = this.products.reduce((sum, product) => sum + product.Product.Price * product.Cantidad, 0);
  }

  removeProduct(product: Producto) {
    console.log('removing product');
    this.carrito.removeProduct(product);
    this.products = this.carrito.getShoppingCart();
  }

  addAmount(product: Carrito) {
    product.Cantidad = product.Cantidad + 1;
    this.carrito.update(product.Product, product.Cantidad);

    this.totalPrice = this.products.reduce((sum, product) => sum + product.Product.Price * product.Cantidad, 0);
  }

  removeAmount(product: Carrito) {
    if (product.Cantidad > 1) {
      product.Cantidad = product.Cantidad - 1;
      this.carrito.update(product.Product, product.Cantidad);

      this.totalPrice = this.products.reduce((sum, product) => sum + product.Product.Price * product.Cantidad, 0);
    }

  }

  registerBuy() {
    this.clientService.registerBuy(this.products).subscribe({
      next: (response) => {

        this.carrito.cleanList();
        this.products = [];
        this.totalPrice = 0;

        this.toastr.success('Compra Registrada Correctamente!!');
      },
      error: (err) => {
        console.error('Error registering buy:', err);

        this.toastr.error('Error al Registrar Compra.\n' + err.error.detail);
      }
    });
  }

}
