import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
 
import { InsurrancesComponent }      from '../components/Insurrances/Insurrances.component';
import { InsurranceDetailComponent }  from '../components/Insurrance-detail/Insurrance-detail.component';
import { LoginComponent }  from '../components/login/login.component';
 
const routes: Routes = [
  { path: '', redirectTo: '/Login', pathMatch: 'full' },
  { path: 'detail/:id', component: InsurranceDetailComponent },
  { path: 'Insurrances', component: InsurrancesComponent },
  { path: 'Login', component: LoginComponent }
];
 
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}