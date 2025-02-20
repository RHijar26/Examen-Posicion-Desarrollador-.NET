import { Component } from '@angular/core';
import { Cliente } from '../../Models/Clientes/Cliente';
import { ClienteService } from '../../Services/Cliente/cliente.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { SearchClientComponent } from '../../Dialogs/search-client/search-client.component';

@Component({
  selector: 'app-clientes',
  standalone: false,
  templateUrl: './clientes.component.html',
  styleUrl: './clientes.component.css'
})
export class ClientesComponent {
  Client: Cliente = {
    Id: 0,
    Name: '',
    Surnames: '',
    Address: '',
    User: '',
    PassWord: '',
  };
    

  constructor(private clientService: ClienteService, private toastr: ToastrService, private dialog: MatDialog) { }

  save() {
    this.clientService.saveClient(this.Client).subscribe({
      next: (response) => {
        this.Client = response;

        this.toastr.success('Cliente Guardado Correctamente!!');
      },
      error: (err) => {
        console.error('Error creating product:', err);

        this.toastr.error('Error al Guardar el Cliente.\n' + err.error.detail);
      }
    });
  }

  remove() {
    const result = this.clientService.removeClient(this.Client.Id).subscribe({
      next: (response) => {

        this.Client = new Cliente();

        this.toastr.success('Cliente eliminado Correctamente');
      },
      error: (err) => {
        console.error('Error removing product:', err);

        this.toastr.error('Error al Eliminar el cliente.\n' + err.error.detail);
      }
    });;    
  }

  openDialog() {
    const dialogRef = this.dialog.open(SearchClientComponent);
  

    dialogRef.afterClosed().subscribe(result => {  
      if (result) {
        this.Client = result;
      }
    });
  }

  clean() {
    this.Client = new Cliente();
  }
}
