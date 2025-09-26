import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Products } from '../../models/products.model';
import { EmployeesService } from '../../service/employees.service';
import { ShippersService } from '../../service/shippers.service';
import { ProductService } from '../../service/products.service';
import { OrderService } from '../../service/orders.service';
import { Shippers } from '../../models/shippers.model';
import { Employees } from '../../models/employees.model';

@Component({
  selector: 'app-new-order',
  standalone: false,
  templateUrl: './new-order.component.html',
  styleUrl: './new-order.component.css'
})
export class NewOrderComponent implements OnInit {

  order = {
    employee: null as number | null,
    shipper: null as number | null,
    shipName: '',
    shipAddress: '',
    shipCity: '',
    shipCountry: '',
    orderDate: '',
    requiredDate: '',
    shippedDate: '',
    freight: null
  };

  orderDetail = {
    productId: null as number | null,
    unitPrice: null as number | null,
    quantity: null as number | null,
    discount: null as number | null
  };

  employees: Employees[] = [];
  shippers: Shippers[] = [];
  products: Products[] = [];

  constructor(
    private router: Router,
    private employeesService: EmployeesService,
    private shippersService: ShippersService,
    private productService: ProductService,
    private orderService: OrderService,

  ) { }

  ngOnInit(): void {
    this.loadEmployees();
    this.loadShippers();
    this.loadProducts();
  }

  loadEmployees(): void {
    this.employeesService.getEmployees().subscribe({
      next: data => this.employees = data,
      error: err => console.error('Error fetching employees:', err)
    });
  }

  loadShippers(): void {
    this.shippersService.getShippers().subscribe({
      next: data => this.shippers = data,
      error: err => console.error('Error fetching shippers:', err)
    });
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe({
      next: data => this.products = data,
      error: err => console.error('Error fetching products:', err)
    });
  }

  onCloseClick(): void {
    this.router.navigate(['/clients']);
  }

  onSaveClick(): void {
    const orderData = {
      employee: this.order.employee,
      shipper: this.order.shipper,
      shipName: this.order.shipName,
      shipAddress: this.order.shipAddress,
      shipCity: this.order.shipCity,
      shipCountry: this.order.shipCountry,
      orderDate: this.order.orderDate,
      requiredDate: this.order.requiredDate,
      shippedDate: this.order.shippedDate,
      freight: this.order.freight,
      orderDetails: [{
        productId: this.orderDetail.productId,
        unitPrice: this.orderDetail.unitPrice,
        quantity: this.orderDetail.quantity,
        discount: this.orderDetail.discount
      }]
    };

    this.orderService.saveOrder(orderData).subscribe({
      next: response => {
        console.log('Order guardada exitosamente:', response);
        this.router.navigate(['/']);
      },
      error: error => {
        console.error('Error guardando la orden:', error);
      }
    });
  }
}
