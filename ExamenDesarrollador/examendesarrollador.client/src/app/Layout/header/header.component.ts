import { Component } from '@angular/core';
import { AuthService } from '../../Services/Authentication/auth-service.service';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  constructor(public authService: AuthService) { }

  onUserClick() {

  }


}
