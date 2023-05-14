import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ErrorDialogComponent } from '../errors/component/error-dialog.component';
import { ErrorDialogService } from '../errors/error-dialog.service';
import { MaterialExampleModule } from '../material.modul';
import  { MyTelInput } from './components/example-tel-input-example/example-tel-input-example.component'
import { ReactiveFormsModule } from '@angular/forms';
import { PhoneInputComponent } from './components/phone-input/phone-input.component';
import { MatFormFieldModule } from '@angular/material/form-field';
@NgModule({
  declarations: [
    ErrorDialogComponent,
    MyTelInput,
    PhoneInputComponent,
  ],
  imports: [
    CommonModule,
    MaterialExampleModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    MatFormFieldModule
  ],
  providers: [
    ErrorDialogService
  ],
  exports: [
    CommonModule,
    MaterialExampleModule,
    ErrorDialogComponent,
    FontAwesomeModule,
    PhoneInputComponent
  ]
})
export class SharedModule { }
