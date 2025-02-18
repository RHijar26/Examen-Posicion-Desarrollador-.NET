import { Component } from '@angular/core';
import { Tienda } from '../../Models/Tienda/Tienda';
import { ToastrService } from 'ngx-toastr';
import { TiendaService } from '../../Services/Tienda/tienda-service.service';
import { MatDialog } from '@angular/material/dialog';
import { SearchClientComponent } from '../../Dialogs/search-client/search-client.component';
import { Cliente } from '../../Models/Clientes/Cliente';
import { SearchShopComponent } from '../../Dialogs/search-shop/search-shop.component';

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
  }


  constructor(private shopService: TiendaService, private toastr: ToastrService, private dialog: MatDialog) { }

  save() {
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
      }
    });
  }

  clean() {
    this.Shop = new Tienda();
  }

}
