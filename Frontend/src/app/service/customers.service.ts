import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_ENDPOINTS } from '../core/constants/api-endpoints';
import { environment } from '../../environments/environment';
import { Customers } from '../models/customers.model';
import { PagedResult } from '../models/paged-result.model';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getPredictions(
    page: number = 1,
    pageSize: number = 10,
    desc: boolean = false
  ): Observable<PagedResult<Customers>> {
    const url = `${this.baseUrl}${API_ENDPOINTS.GET_PREDICTIONS}`;
    console.log(url);
    return this.http.get<PagedResult<Customers>>(url, {
      params: {
        page: page.toString(),
        pageSize: pageSize.toString(),
        desc: desc.toString()
      }
    });
  }
}
