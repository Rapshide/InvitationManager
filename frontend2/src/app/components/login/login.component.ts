import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/auth.service';
import { EMAIL_REGEXP } from 'src/app/models/email';
import { LoginService } from 'src/app/services/login.service';
import {TranslateService} from '@ngx-translate/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  form: FormGroup = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email,
      Validators.pattern(EMAIL_REGEXP),
    ]),
    password: new FormControl('', Validators.required),
  });

  public loading: boolean;
  public showPassword: boolean = false;

  constructor(
    private loginService: LoginService,
    private authService: AuthService,
    private router: Router,
    public translate: TranslateService
  ) {
    translate.addLangs(['en', 'fr']);
    translate.setDefaultLang('en');

    const browserLang = translate.getBrowserLang();
    translate.use(browserLang.match(/en|fr/) ? browserLang : 'en');
  }

  submit() {
    this.error = undefined;
    this.loading = true;
    if (this.form.valid) {
      this.loginService.login(this.form.value).subscribe({
        next: (response: {id: string; email: string}) => {
          this.router.navigate(['/', 'dashboard']);
        },
        error: (error: HttpErrorResponse) => {
          this.loading = false;
          if (error.status === 401) {
            this.error = 'Invalid credentials';
          } else {
            throw new HttpErrorResponse(error);
          }
        },
        complete: () => {
          this.loading = false;
        },
      });
    }
  }

  public togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }

  @Input() error: string | null;
  matcher = new MyErrorStateMatcher();
}
