import { Component, EventEmitter, Inject, OnInit,Output } from '@angular/core';
import { ProductoService } from '../../Services/Producto/producto.service';
import { ToastrService } from 'ngx-toastr';
import { Producto } from '../../Models/Productos/Producto';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

// Example product interface

@Component({
  selector: 'app-search-products',
  standalone: false,
  templateUrl: './search-products.component.html',
  styleUrls: ['./search-products.component.css']
})
export class SearchProductsComponent implements OnInit {
  searchTerm: string = '';
  products: Producto[] = []
  filteredProducts: Producto[] = [];  
  constructor(
    private productService: ProductoService,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<SearchProductsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { selectedProducts: Producto[] }
  ) { }

  ngOnInit() {    
    this.productService.getProduct().subscribe({
      next: (data) => {

        if (this.data.selectedProducts.length > 0)
        {
          this.products = data.filter(product =>
            !this.data.selectedProducts.some(selected => selected.Id === product.Id)
          );
        } else {
          this.products = data;
        }
          
        this.filteredProducts = this.products;        
      },
      error: (error) => {
        console.error('Error fetching products:', error);

        this.toastr.error('Error al consultar productos');
      }
    });

  }

  selectProduct(product: Producto) {    
    this.dialogRef.close(product);
  }

  searchProducts() {
    const term = this.searchTerm.toLowerCase();
    // If no search term, show all
    if (!term) {
      this.filteredProducts = this.products;
    } else {
      // Filter products by name
      this.filteredProducts = this.products.filter(product =>
        product.Name.toLowerCase().includes(term)
      );
    }
  }

  close() {
    this.dialogRef.close();
  }
}
