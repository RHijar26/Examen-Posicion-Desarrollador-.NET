import { Component, inject } from '@angular/core';
import { CarritoService } from '../../Services/Carrito/carrito.service';
import { Carrito } from '../../Models/Carrito/Carrito';

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

  constructor() { }



  ngOnInit() {
    this.products = this.carrito.getShoppingCart();
  }

}
