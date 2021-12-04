import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  user: any = null;
  constructor(private router: Router) { }

  ngOnInit(): void {
    //this.obtenerToken();
    if (this.user != null) {
      this.router.navigate(['/']);
    }
  }

  obtenerToken() {
    this.user = { 'id': 'ASD-ML234-SDF23DA', 'userName': 'Leonardo Burgos Diaz', 'email': 'leburgosdiaz@gmail.com' };
    localStorage.setItem(
      'userResponse',
      JSON.stringify(this.user)
    );
  }

  autenticar() {
    this.obtenerToken();
    if (this.user != null) {
      this.router.navigate(['/']);
    }
  }
}
