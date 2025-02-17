import { Producto } from "../Productos/Producto";

export class Carrito {
  Producto!: Producto;
  Cantidad!: number;

  constructor(producto: Producto, cantidad: number)
  {
    this.Producto = producto;
    this.Cantidad = cantidad;
  }

}


