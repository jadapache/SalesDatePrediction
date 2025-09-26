import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shippers } from '../models/shippers.model';
import { API_ENDPOINTS } from '../core/constants/api-endpoints';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getShippers(): Observable<Shippers[]> {
    const url = `${this.baseUrl}${API_ENDPOINTS.GET_SHIPPERS}`;
    return this.http.get<Shippers[]>(url);
  }
}
