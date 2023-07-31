import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order.model';
import { OrderService } from 'src/app/services/order.service';

@Component({
  templateUrl: './index.component.html'
})
export class Index3Component implements OnInit {
    orders: Order[];
    selectedOrder: Order;

    constructor(
        private orderService: OrderService,
    ) {}
  ngOnInit(): void {
    this.orderService.findAll().then(
        result => {
            console.log(result);
            this.orders = result as Order[];
        },
        error => {
            console.log(error);
        }
    );
  }
}