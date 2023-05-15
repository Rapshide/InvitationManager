import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EditTimeComponent } from './components/edit-time/edit-time.component';
import { UserEditComponent } from './components/user-edit/user-edit.component';
import { NgxPermissionsGuard } from 'ngx-permissions';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [NgxPermissionsGuard],
    canActivateChild: [NgxPermissionsGuard],
    data: {
      permissions: { only: 'Admin' },
    },
    children: [
      {
        path: 'anyad',
        component: UserEditComponent,
        canActivate: [NgxPermissionsGuard],
        data: {
          permissions: { only: 'Admin' },
        },
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
