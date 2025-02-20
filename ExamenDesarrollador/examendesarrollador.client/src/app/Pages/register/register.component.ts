import { Component } from '@angular/core';
import { Cliente } from '../../Models/Clientes/Cliente';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ClienteService } from '../../Services/Cliente/cliente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  Client: Cliente = {
    Id: 0,
    Name: '',
    Surnames: '',
    Address: '',
    User: '',
    PassWord: '',
  };

  constructor(private clientService: ClienteService, private toastr: ToastrService, private dialog: MatDialog, private router: Router) { }

  register() {
    this.clientService.saveClient(this.Client).subscribe({
      next: (response) => {
        this.Client = response;

        this.toastr.success('Cliente Guardado Correctamente!!');

        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Error creating product:', err);

        this.toastr.error('Error al Guardar el Cliente.\n' + err.error.detail);
      }
    });
  }


}
