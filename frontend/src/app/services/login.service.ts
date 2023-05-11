import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Response } from '../models/response';
import { Token } from '../models/token';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(
    private http: HttpClient
  ) { }

  login(credentials: any): Observable<Response<Token>>{
    return this.http.post<Response<Token>>(`${environment.baseURL}/api/login`, credentials);
  }

  register(form: any): Observable<Response<any>>{
    return this.http.post<Response<any>>(`${environment.baseURL}/api/register`, form);
  }
}
