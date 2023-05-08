import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, finalize, takeUntil } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { EMAIL_REGEXP } from 'src/app/models/email';
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
    email: new FormControl('', [
      Validators.required,
      Validators.email,
      Validators.pattern(EMAIL_REGEXP),
    ]),
    name: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  constructor(
    private loginService: LoginService,
    private authService: AuthService,
    private router: Router
  ) {}

  submit() {
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
          next: (response: Response<any>) => {
            this.authService.saveToken(response.result);
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
