import { Component } from '@angular/core';
import { Producto } from '../../Models/Productos/Producto';

@Component({
  selector: 'app-productos',
  standalone: false,
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css'
})


export class ProductosComponent {
  producto: Producto = {
    id: 0,
    name: '',
    code: '',
    price: 0,
    stock: 0
  };

  save() {
    
  }
}
