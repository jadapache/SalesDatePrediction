import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Products } from '../models/products.model';
import { API_ENDPOINTS } from '../core/constants/api-endpoints';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Products[]> {
    const url = `${this.baseUrl}${API_ENDPOINTS.GET_PRODUCTS}`;
    return this.http.get<Products[]>(url);
  }
}
