import { Producto } from "../Productos/Producto";

export class Carrito {
  Product!: Producto;
  Cantidad!: number;

  constructor(producto: Producto, cantidad: number)
  {
    this.Product = producto;
    this.Cantidad = cantidad;
  }

}


