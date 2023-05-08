import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialExampleModule } from '../material.modul';
import { ErrorDialogService } from '../errors/error-dialog.service';
import { ErrorDialogComponent } from '../errors/component/error-dialog.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    ErrorDialogComponent
  ],
  imports: [
    CommonModule,
    MaterialExampleModule,
    FontAwesomeModule
  ],
  providers: [
    ErrorDialogService
  ],
  exports: [
    CommonModule,
    MaterialExampleModule,
    ErrorDialogComponent,
    FontAwesomeModule
  ]
})
export class SharedModule { }
