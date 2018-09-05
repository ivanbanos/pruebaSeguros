import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

import { Usuario } from '../../model/Usuario';
import { LoginService }  from '../../services/Login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, private LoginService: LoginService,) { }

  ngOnInit() {
  }
  login(NombreUsuario: string, contrasena: string): void {
    this.LoginService.Login({ NombreUsuario:NombreUsuario, Contrasena: contrasena, Token:"" } as Usuario).subscribe(token => {
      
      if( token != "401"){
        this.router.navigate(['/Insurrances']);
      } 
    });

  }
}
