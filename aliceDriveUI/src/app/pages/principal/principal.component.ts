import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.scss']
})
export class PrincipalComponent implements OnInit {
  usuario: any = null;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.usuario = JSON.parse(localStorage.getItem('userResponse') as string);

    if (this.usuario == null) {
      this.router.navigate(['/auth']);
    }
    console.log(this.route.snapshot.params);
  }

  cerrarSesion() {
    localStorage.clear();
    this.router.navigate(['/auth']);
  }

}
