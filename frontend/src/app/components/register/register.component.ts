import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, finalize, takeUntil } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { EMAIL_REGEXP } from 'src/app/models/email';
import { MyTel } from 'src/app/models/phone';
import { Response } from 'src/app/models/response';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  public loading: boolean;
  public showPassword: boolean = false;
  @Input() error: string | null;

  private destroyed$ = new Subject<void>();

  form: FormGroup = new FormGroup({
    Email: new FormControl('', [
      Validators.required,
      Validators.email,
      Validators.pattern(EMAIL_REGEXP),
    ]),
    Name: new FormControl('', Validators.required),
    Password: new FormControl('', Validators.required),
    PhoneNumber: new FormControl(new MyTel('', '', ''), Validators.required),
    Role: new FormControl('', Validators.required),
  });

  constructor(
    private loginService: LoginService,
    private authService: AuthService,
    private router: Router
  ) {}

  submit() {
    console.log(this.form.value);
    
    this.error = undefined;
    this.loading = true;
    if (this.form.valid) {
      this.loginService
        .register(this.form.value)
        .pipe(
          takeUntil(this.destroyed$),
          finalize(() => (this.loading = false))
        )
        .subscribe({
          next: (response: any) => {
            this.authService.saveToken(response.id);
            this.router.navigate(['']);
          },
          error: (error: HttpErrorResponse) => {
            throw new HttpErrorResponse(error);
          },
        });
    }
  }

  public togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }

  ngOnDestroy(): void {
    this.destroyed$.next();
    this.destroyed$.complete();
  }
}
