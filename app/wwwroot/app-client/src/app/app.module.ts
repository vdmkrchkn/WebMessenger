import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AddComponent } from './messages/add/add.component';
import { ListComponent } from './messages/list/list.component';
import { MessageService } from './services/message.service';
import { HistoryComponent } from './messages/history/history.component';
import { LoginComponent } from './auth/login.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthGuard } from './auth/auth.guard';
import { AuthenticationService } from './services/authentication.service';
import { AuthenticationClientService } from './services/authentication-client.service';
import { MainComponent } from './main/main.component';

@NgModule({
  declarations: [
	AppComponent,
	AddComponent,
	ListComponent,
	HistoryComponent,
	LoginComponent,
	MainComponent,
  ],
  imports: [
	BrowserModule,
	FormsModule,
    ReactiveFormsModule,
	HttpClientModule,
	AppRoutingModule,
  ],
  providers: [
	MessageService,
	AuthGuard,
	AuthenticationService,
	AuthenticationClientService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
