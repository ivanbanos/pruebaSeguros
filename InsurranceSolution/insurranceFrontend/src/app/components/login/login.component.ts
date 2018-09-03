import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

import { Usuario } from '../../model/Usuario';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  usuario: Usuario;
  constructor(private router: Router) { }

  ngOnInit() {
  }
  login(): void {
    this.router.navigate(['/Insurrances']);
  }
}
