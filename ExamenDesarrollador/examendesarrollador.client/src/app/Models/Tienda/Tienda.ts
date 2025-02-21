import { ProductoTienda } from "../Productos/ProductoTienda";

export class Tienda {
  Id!: number;
  Sucursal!: string;
  Address!: string;

  ProductShop!: ProductoTienda[]
}
