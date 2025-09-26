import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_ENDPOINTS } from '../core/constants/api-endpoints';
import { Orders } from '../models/orders.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class OrderService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getOrdersByCustomerId(customerId: string): Observable<Orders[]> {
    const url = `${this.baseUrl}${API_ENDPOINTS.GET_ORDERS_BY_CUSTOMER}${customerId}`;
    return this.http.get<Orders[]>(url);
  }

  saveOrder(order: any): Observable<any> {
    const discount = order.orderDetails[0].discount;
    const validDiscount = (discount != null && discount >= 0 && discount <= 1)
                          ? parseFloat(discount.toFixed(3))
                          : 0;

    const orderPayload = {
      empId: order.employee,
      shipperId: order.shipper,
      shipName: order.shipName,
      shipAddress: order.shipAddress,
      shipCity: order.shipCity,
      orderDate: order.orderDate,
      requiredDate: order.requiredDate,
      shippedDate: order.shippedDate,
      freight: order.freight,
      shipCountry: order.shipCountry,
      orderDetails: [
        {
          productId: order.orderDetails[0].productId,
          unitPrice: parseFloat(order.orderDetails[0].unitPrice?.toFixed(2) || '0'),
          quantity: order.orderDetails[0].quantity,
          discount: validDiscount,
        }
      ]
    };
    const url = `${this.baseUrl}${API_ENDPOINTS.CREATE_ORDER}`;
    return this.http.post(url, orderPayload);
  }

}
