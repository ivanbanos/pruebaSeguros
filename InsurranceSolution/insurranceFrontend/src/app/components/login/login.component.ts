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
  usuario: Usuario;
  constructor(private router: Router, private LoginService: LoginService,) { }

  ngOnInit() {
  }
  login(NombreUsuario: string, contrasena: string): void {
    this.LoginService.Login({ NombreUsuario:NombreUsuario, id:0, Contrasena: contrasena, Token:"" } as Usuario).subscribe(usuario => {
      this.usuario = usuario;
      if( usuario.Token != ""){
        this.router.navigate(['/Insurrances']);
      }
    });

  }
}
