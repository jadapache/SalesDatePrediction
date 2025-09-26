import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { OrderService } from '../../service/orders.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Orders } from '../../models/orders.model';

@Component({
  selector: 'app-orders-view',
  standalone: false,
  templateUrl: './orders-view.component.html',
  styleUrl: './orders-view.component.css'
})
export class OrdersViewComponent implements OnInit {
  customerId: string | null = null;
  orders$: Observable<Orders[]>;
  displayedColumns: string[] = ['orderId', 'requiredDate', 'shippedDate', 'shipName', 'shipAddress', 'shipCity'];

  dataSource = new MatTableDataSource<Orders>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private route: ActivatedRoute,
    private orderService: OrderService,
    private router: Router
  ) {
    this.customerId = this.route.snapshot.paramMap.get('id');
    this.orders$ = this.orderService.getOrdersByCustomerId(this.customerId!);
  }

  ngOnInit(): void {

    this.orders$.subscribe(orders => {
      this.dataSource.data = orders;
      if (this.paginator) {
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  onCloseClick(): void {
    this.router.navigate(['/']);
  }
}
