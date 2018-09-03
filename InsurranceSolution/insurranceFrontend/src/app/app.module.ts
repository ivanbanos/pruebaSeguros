import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './routes/app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { InsurrancesComponent } from './components/Insurrances/Insurrances.component';
import { InsurranceDetailComponent } from './components/Insurrance-detail/Insurrance-detail.component';
import { MessagesComponent } from './components/messages/messages.component';
import { LoginComponent } from './components/login/login.component';


@NgModule({
  imports: [BrowserModule, FormsModule, AppRoutingModule, HttpClientModule],
  declarations: [
    AppComponent,
    InsurrancesComponent,
    InsurranceDetailComponent,
    MessagesComponent,
    LoginComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}