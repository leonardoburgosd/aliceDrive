import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'aliceDrive';
  usuario: any = null;
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.usuario = { 'nombre':'Leonardo Burgos' };
    if (this.usuario != null) {
      this.router.navigate(['/file']);
    } else {
      this.router.navigate(['/auth']);
    }
  }
}
