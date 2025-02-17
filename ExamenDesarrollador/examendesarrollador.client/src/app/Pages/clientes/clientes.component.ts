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
    Address: ''
  };
    

  constructor(private clientService: ClienteService, private toastr: ToastrService, private dialog: MatDialog) { }

  save() {
    this.clientService.saveClient(this.Client).subscribe({
      next: (response) => {
        this.Client = response;

        this.toastr.success('Cliente Creado Correctamente!!');
      },
      error: (err) => {
        console.error('Error creating product:', err);

        this.toastr.error('Error al Guardar el Cliente.\n' + err.error.detail);
      }
    });
  }

  openDialog() {
    this.dialog.open(SearchClientComponent);
  }
}
