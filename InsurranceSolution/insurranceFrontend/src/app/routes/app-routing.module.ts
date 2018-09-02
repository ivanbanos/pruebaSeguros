import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
 
import { InsurrancesComponent }      from '../components/Insurrances/Insurrances.component';
import { InsurranceDetailComponent }  from '../components/Insurrance-detail/Insurrance-detail.component';
 
const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'detail/:id', component: InsurranceDetailComponent },
  { path: 'Insurrances', component: InsurrancesComponent }
];
 
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}