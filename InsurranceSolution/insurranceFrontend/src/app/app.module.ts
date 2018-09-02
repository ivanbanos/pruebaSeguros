import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
 
 
import { AppRoutingModule }     from './app-routing.module';
 
import { AppComponent }         from './app.component';
import { InsurranceDetailComponent }  from './Insurrance-detail/Insurrance-detail.component';
import { InsurrancesComponent }      from './Insurrances/Insurrances.component';
import { MessagesComponent }    from './messages/messages.component';
 
@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
 
  ],
  declarations: [
    AppComponent,
    InsurrancesComponent,
    InsurranceDetailComponent,
    MessagesComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }