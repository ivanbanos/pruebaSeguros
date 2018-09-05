import { Component } from '@angular/core';
import {Router} from "@angular/router";
import { LoginService }  from 'src/app/services/Login.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  constructor(private router: Router, private LoginService: LoginService,) { }
  title = 'Insurrances';

  logout(): void {
    
    this.LoginService.logout();
    this.router.navigate(['/Login']);
  }

}
