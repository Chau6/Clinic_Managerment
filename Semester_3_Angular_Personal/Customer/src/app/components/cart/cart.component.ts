import { Component, OnInit } from '@angular/core';
import { Account } from 'src/app/models/account.model';
import { Cart } from 'src/app/models/cart.model';
import { AccountService } from 'src/app/services/account.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-root',
  templateUrl: './cart.component.html',
})
export class CartComponent implements OnInit {
  carts: Cart[];
  account: Account;
  email: string;
  totalPrice = 0;
  PostUrl: string;
  ReturnUrl: string;
  Business: string;

  constructor(
    private cartService: CartService,
    private accountService: AccountService
  ) {}

  ngOnInit() {
    //paypal
    this.PostUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr";
    this.ReturnUrl = "http://localhost:50997/paid";
    this.Business = "sb-ft043u25490117@business.example.com";

    this.email = localStorage.getItem('email');
    this.accountService.findByEmail(this.email).then(
      (result) => {
        this.account = result as Account;
        this.cartService.find(this.account.accountId).then(
          (result) => {
            console.log(result);
            this.carts = result as Cart[];
            this.calculateTotal();
          },
          (error) => {
            console.log(error);
          }
        );
      },
      (error) => {
        console.log(error);
      }
    );
  }

  delete(id: any) {
    var cartId = parseInt(id);
    console.log(cartId);
    if (confirm('Are you sure you want to delete this item?')) {
      this.cartService.delete(id).then(
        (result) => {
          console.log(result);
          if (result) {
            alert("Delete successfully !");
            window.location.reload();
          }
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  add(id: any) {
    var cartId = parseInt(id);
    console.log(cartId);
    this.cartService.addQuantity(id).then(
      (result) => {
        console.log(result);
        if(result){
          alert("Add Quantity Successfully !")
          window.location.reload();
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }

  sub(id: any) {
    var cartId = parseInt(id);
    console.log(cartId);
    this.cartService.subQuantity(id).then(
      (result) => {
        console.log(result);
        if(result){
          alert("Subtract Quantity Successfully !")
          window.location.reload();
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }

  calculateTotal() {
    this.totalPrice = 0;
    for (const cart of this.carts) {
      this.totalPrice += cart.quantity * cart.productPrice + 10;
    }
  }
}
