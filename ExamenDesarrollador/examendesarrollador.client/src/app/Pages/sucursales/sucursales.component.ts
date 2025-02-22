import { Component } from '@angular/core';
import { Tienda } from '../../Models/Tienda/Tienda';
import { ToastrService } from 'ngx-toastr';
import { TiendaService } from '../../Services/Tienda/tienda-service.service';
import { MatDialog } from '@angular/material/dialog';
import { SearchClientComponent } from '../../Dialogs/search-client/search-client.component';
import { Cliente } from '../../Models/Clientes/Cliente';
import { SearchShopComponent } from '../../Dialogs/search-shop/search-shop.component';
import { ProductoService } from '../../Services/Producto/producto.service';
import { Producto } from '../../Models/Productos/Producto';
import { SearchProductsComponent } from '../../Dialogs/search-product/search-products.component';
import { ProductoTienda } from '../../Models/Productos/ProductoTienda';

@Component({
  selector: 'app-sucursales',
  standalone: false,
  templateUrl: './sucursales.component.html',
  styleUrl: './sucursales.component.css'
})
export class SucursalesComponent {
  Shop: Tienda = {
    Id: 0,
    Sucursal: '',
    Address: '',
    ProductShop: [],
  }

  products: Producto[] = [];


  constructor(private shopService: TiendaService, private productService: ProductoService, private toastr: ToastrService, private dialog: MatDialog) { } 


  save() {

    this.Shop.ProductShop = [];

    this.products.forEach(product => {
      const productShop = new ProductoTienda();

      productShop.ProductId = product.Id;
      productShop.ShopId = this.Shop.Id;

      this.Shop.ProductShop.push(productShop);

    });

    this.shopService.saveShop(this.Shop).subscribe({
      next: (response) => {
        this.Shop = response;

        this.toastr.success('Tienda Guardada Correctamente!!');
      },
      error: (err) => {
        console.error('Error saving Shop:', err);

        this.toastr.error('Error al Guardar la Tienda.\n' + err.error.detail);
      }
    });
  }

  remove() {
    const result = this.shopService.removeShop(this.Shop.Id).subscribe({
      next: (response) => {

        this.Shop = new Tienda();

        this.toastr.success('Tienda eliminada Correctamente');
      },
      error: (err) => {
        console.error('Error removing shop:', err);

        this.toastr.error('Error al Eliminar la tienda.\n' + err.error.detail);
      }
    });;
  }

  openDialog() {
    const dialogRef = this.dialog.open(SearchShopComponent);


    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.Shop = result;

        this.productService.getProductsFromShop(this.Shop.Id).subscribe({
          next: (response) => {

            this.products = response;
          },
          error: (err) => {
          }
        })


      }
    });
  }

  openProductDialog() {
    const dialogRef = this.dialog.open(SearchProductsComponent, {
      data: { selectedProducts: this.products }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {

        this.products.push(result);
      }

    });
   
  }

  removeProduct(product: Producto) {
    const index = this.products.findIndex(p => p.Id == product.Id);

    if (index != -1) {
      this.products.splice(index, 1);       
    }
  }

  clean() {
    this.Shop = new Tienda();
    this.products = [];
  }

}
