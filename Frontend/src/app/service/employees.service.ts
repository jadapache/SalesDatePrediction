import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employees } from '../models/employees.model';
import { API_ENDPOINTS } from '../core/constants/api-endpoints';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<Employees[]> {
    const url = `${this.baseUrl}${API_ENDPOINTS.GET_EMPLOYEES}`;
    return this.http.get<Employees[]>(url);
  }
}
