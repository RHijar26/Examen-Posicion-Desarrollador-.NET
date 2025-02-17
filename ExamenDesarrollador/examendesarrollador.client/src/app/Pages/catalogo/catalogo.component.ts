import { Component, inject } from '@angular/core';
import { CarritoService } from '../../Services/Carrito/carrito.service';
import { Producto } from '../../Models/Productos/Producto';
import { ToastrService } from 'ngx-toastr';
import { ProductoService } from '../../Services/Producto/producto.service';

@Component({
  selector: 'app-catalogo',
  standalone: false,
  templateUrl: './catalogo.component.html',
  styleUrl: './catalogo.component.css',  
})
export class CatalogoComponent {

  products: Producto[] = [];
  carrito = inject(CarritoService);

  constructor(private productService: ProductoService, private toastr: ToastrService) { }


  ngOnInit() {
    this.productService.obtenerProductos().subscribe({
      next: (data) => {

        this.products = data;                
      },
      error: (error) => {        

        this.toastr.error('Error al consultar productos');
      }
    });

  }

  addProductShoppingCart(product: Producto)
  {
    this.carrito.add(product);
  }

}
