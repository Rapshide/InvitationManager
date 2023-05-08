import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { MainComponent } from './components/main/main.component';
import { AuthGuardService } from './auth/auth-guard.service';
import { NotAuthGuardService } from './auth/not-auth-guard.service';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuardService], children: [
    { path:'', component: MainComponent, canActivate: [AuthGuardService] },
  ] },
  { path: 'login', component: LoginComponent, canActivate: [NotAuthGuardService] },
  { path: 'register', component: RegisterComponent, canActivate: [NotAuthGuardService] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
