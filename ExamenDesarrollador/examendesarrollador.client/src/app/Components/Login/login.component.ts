import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private router: Router) { }

  ngOnInit(): void { }

  private navegar(): void {
    this.router.navigateByUrl('/inicio');
  }

  ingresar(event: Event): void {
    event.preventDefault(); // Evita que se recargue la página

    this.navegar();
  }
}
