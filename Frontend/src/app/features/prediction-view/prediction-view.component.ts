import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CustomersService } from '../../service/customers.service';
import { Customers } from '../../models/customers.model';

@Component({
  selector: 'app-prediction-view',
  standalone: false,
  templateUrl: './prediction-view.component.html',
  styleUrl: './prediction-view.component.css'
})
export class PredictionViewComponent implements OnInit {
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'actions'];
  dataSource = new MatTableDataSource<Customers>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private customersService: CustomersService) {}

 ngOnInit(): void {
  this.customersService.getPredictions().subscribe({
    next: (data) => {
      this.dataSource.data = data.items;
      this.paginator.length = data.totalCount;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    },
    error: (err) => console.error('Error al cargar datos', err)
  });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
