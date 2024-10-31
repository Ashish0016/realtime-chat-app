import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ApiInterceptor } from 'src/core/Interceptor/api.interceptor';
import { ChatAppComponent } from './components/chat-app/chat-app.component';
import { SignalrService } from 'src/services/signalr-service/signalr.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthenticationModule } from './components/authentication/authentication.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    ChatAppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AuthenticationModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(
      {
        timeOut: 3000,  // Duration for which the toast should appear
        positionClass: 'toast-top-right',  // Position of the toast
        preventDuplicates: true,  // Prevents duplicate toasts
      }
    )
  ],
  providers: [
    SignalrService,
    { provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
