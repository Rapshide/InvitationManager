import { ErrorHandler, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { registerLocaleData } from '@angular/common';
import localeHu from '@angular/common/locales/hu';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { provideEnvironmentNgxMask } from 'ngx-mask';
import { AuthGuardService } from './auth/auth-guard.service';
import { AuthInterceptor } from './auth/auth-interceptor';
import { AuthService } from './auth/auth.service';
import { NotAuthGuardService } from './auth/not-auth-guard.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EditTimeComponent } from './components/edit-time/edit-time.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { GlobalErrorHandler } from './errors/global-error-handler';
import { MaterialExampleModule } from './material.modul';
import { SharedModule } from './shared/shared.module';
registerLocaleData(localeHu);
@NgModule({
  declarations: [AppComponent, LoginComponent, RegisterComponent, DashboardComponent, EditTimeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    MaterialExampleModule,
    ReactiveFormsModule,
    SharedModule,
    FormsModule,
  ],
  providers: [
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    AuthService,
    AuthGuardService,
    NotAuthGuardService,
    JwtHelperService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    provideEnvironmentNgxMask(),
    { provide: LOCALE_ID, useValue: 'hu' },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
