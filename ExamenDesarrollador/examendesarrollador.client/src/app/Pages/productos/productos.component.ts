import { Component } from '@angular/core';
import { Producto } from '../../Models/Productos/Producto';
import { ProductoService } from '../../Services/Producto/producto.service';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-productos',
  standalone: false,
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css'
})


export class ProductosComponent {
  producto: Producto = {
      Id: 0,
      Name: '',
      Code: '',
      Price: 0,
      Stock: 0,
      Image: ''
  };

  constructor(private productService: ProductoService, private toastr: ToastrService) { }

  save() {
    this.productService.guardarProducto(this.producto).subscribe({
      next: (response) => {
        console.log('Product created successfully:', response);
        // You might show a success message, reset form, etc.

        this.toastr.success('Producto Creado Correctamente!!');
      },
      error: (err) => {
        console.error('Error creating product:', err);

        this.toastr.error('Error al Guardar el Producto.\n' + err.error.detail);
      }
    });
  }

  clean() {
    this.producto = new Producto();
  }

  onProductSelected(product: Producto) {    
    this.producto = product;

    const closeButton = document.getElementById('closeModalBtn') as HTMLElement;
    if (closeButton) {
      closeButton.click();
    }
  }
}
