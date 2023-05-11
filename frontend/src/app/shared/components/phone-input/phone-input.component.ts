import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-phone-input',
  templateUrl: './phone-input.component.html',
  styleUrls: ['./phone-input.component.css']
})
export class PhoneInputComponent implements OnInit {
  @Input() hasFormControlName!: string;
  @Input() hasFormGroup!: FormGroup;

  formControlValidator!: boolean;

  ngOnInit(): void {
    this.formControlValidator = this.hasFormGroup.get(this.hasFormControlName).valid;
  }
}
