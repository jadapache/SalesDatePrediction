import { Routes } from '@angular/router';
import { PredictionViewComponent } from './features/prediction-view/prediction-view.component';
import { OrdersViewComponent } from './features/orders-view/orders-view.component';
import { NewOrderComponent } from './features/new-order/new-order.component';


export const routes: Routes = [
    { path: '', component: PredictionViewComponent },
    { path: 'view-orders/:id', component: OrdersViewComponent },
    { path: 'new-order', component: NewOrderComponent },
    { path: '**', redirectTo: '' }
];
