import { Component } from '@angular/core';
import { Producto } from '../../Models/Productos/Producto';
import { ProductoService } from '../../Services/Producto/producto.service';

import { ToastrService } from 'ngx-toastr';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { SearchShopComponent } from '../../Dialogs/search-shop/search-shop.component';
import { SearchProductsComponent } from '../../Dialogs/search-product/search-products.component';

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

  constructor(private productService: ProductoService, private toastr: ToastrService, private dialog: MatDialog) { }

  save() {
    this.productService.saveProduct(this.producto).subscribe({
      next: (response) => {
        this.producto = response;

        this.toastr.success('Producto Guardado Correctamente!!');
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

  remove() {
    const result = this.productService.removeProduct(this.producto.Id).subscribe({
      next: (response) => {

        this.producto = new Producto();

        this.toastr.success('Producto eliminado Correctamente');
      },
      error: (err) => {
        console.error('Error removing product:', err);

        this.toastr.error('Error al Eliminar el Producto.\n' + err.error.detail);
      }
    });;    
  }

  openDialog() {
    const dialogRef = this.dialog.open(SearchProductsComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.producto = result;
      }
    });
  }

  onProductSelected(product: Producto) {    
    this.producto = product;

    const closeButton = document.getElementById('closeModalBtn') as HTMLElement;
    if (closeButton) {
      closeButton.click();
    }
  }
}
