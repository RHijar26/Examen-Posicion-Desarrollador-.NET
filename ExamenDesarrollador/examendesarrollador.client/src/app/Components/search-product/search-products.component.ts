import { Component, EventEmitter, OnInit,Output } from '@angular/core';
import { ProductoService } from '../../Services/Producto/producto.service';
import { ToastrService } from 'ngx-toastr';
import { Producto } from '../../Models/Productos/Producto';

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

  @Output() productSelected = new EventEmitter<Producto>(); // EventEmitter to send data
  constructor(private productService: ProductoService,private toastr: ToastrService) { }

  ngOnInit() {    
    this.productService.getProduct().subscribe({
      next: (data) => {

        this.products = data;
        this.filteredProducts = this.products;        
      },
      error: (error) => {
        console.error('Error fetching products:', error);

        this.toastr.error('Error al consultar productos');
      }
    });

  }

  selectProduct(product: Producto) {
    this.productSelected.emit(product);     
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
}
