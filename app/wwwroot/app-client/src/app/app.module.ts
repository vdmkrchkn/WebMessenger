import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AddComponent } from './messages/add/add.component';
import { ListComponent } from './messages/list/list.component';
import { MessageService } from './services/message.service';

@NgModule({
  declarations: [
	AppComponent,
	AddComponent,
	ListComponent
  ],
  imports: [
	BrowserModule,
	FormsModule,
	HttpClientModule
  ],
  providers: [
	MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
