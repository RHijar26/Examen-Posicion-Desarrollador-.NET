import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Cliente } from '../../Models/Clientes/Cliente';
import { ClienteService } from '../../Services/Cliente/cliente.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-search-client',
  standalone: false,
  templateUrl: './search-client.component.html',
  styleUrl: './search-client.component.css'
})
export class SearchClientComponent {
  clients: Cliente[] = []
  filteredClients: Cliente[] = []
  constructor(private dialogRef: MatDialogRef<SearchClientComponent>, private clienteService: ClienteService, private toastr: ToastrService) { }

  ngOnInit() {
    this.clienteService.getClients().subscribe({
      next: (data) => {

        this.clients = data;
        this.filteredClients = this.clients;        
      },
      error: (error) => {
        console.error('Error fetching clients:', error);

        this.toastr.error('Error al consultar los clientes');
      }
    });

  }

  close() {
    this.dialogRef.close();
  }

  clientSelected(client: Cliente)
  {
    
    this.dialogRef.close(client);
  }
}
