import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { TiendaService } from '../../Services/Tienda/tienda-service.service';
import { Tienda } from '../../Models/Tienda/Tienda';

@Component({
  selector: 'app-search-shop',
  standalone: false,
  templateUrl: './search-shop.component.html',
  styleUrl: './search-shop.component.css'
})
export class SearchShopComponent {
  shops: Tienda[] = []  
  constructor(private dialogRef: MatDialogRef<SearchShopComponent>, private shopService: TiendaService, private toastr: ToastrService) { }

  ngOnInit() {
    this.shopService.getShops().subscribe({
      next: (data) => {

        this.shops = data;
      },
      error: (error) => {
        console.error('Error fetching shops:', error);

        this.toastr.error('Error al consultar las Tiendas');
      }
    });

  }

  close() {
    this.dialogRef.close();
  }

  shopSelected(shop: Tienda) {

    this.dialogRef.close(shop);
  }

}
