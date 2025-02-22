import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/Authentication/auth-service.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.authService.logout();
  }

  login() {
    this.authService.login(this.username, this.password).subscribe({
      next: (response) => {
        this.authService.setToken(response.result);
        this.router.navigate(['/catalogo']);
      },
      error: (err) => {
        this.errorMessage = 'Las credenciales Ingresadas No son Validas';

        this.toastr.error('Error al Guardar Usuario.' + err.error.detail);
      }
    });

  }

}
