import { Component, OnInit } from '@angular/core';
import { Product } from './models/product.model';
import { ProductService } from './services/product.service';
import { CartService } from './services/cart.service';
import { AccountService } from './services/account.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Account } from './models/account.model';
import { Cart } from './models/cart.model';

@Component({
  selector: 'promotions',
  templateUrl: './promotion.component.html',
})
export class PromotionComponent implements OnInit {
  products: Product[];
  account: Account;
  email: string;
  addToCart: FormGroup;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private accountService: AccountService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.addToCart = this.formBuilder.group({
      accountId: '',
      productId: '',
      quantity: 1,
      status: true,
    });
    this.productService.findThree().then(
      (result) => {
        console.log(result);
        this.products = result as Product[];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  add(id: any) { //productId
    // console.log(id);
    this.email = localStorage.getItem('email');
    this.accountService.findByEmail(this.email).then(
      (result) => {
        this.account = result as Account;
        // console.log(this.account);
        var cart: Cart = this.addToCart.value as Cart;
        cart.accountId = this.account.accountId;
        cart.productId = parseInt(id);
        console.log(cart);
        this.cartService.create(cart).then(
          result => {
            console.log(result);
            if(result){
              alert("Add to Cart Successful")
            }
          },
          error => {
            console.log(error);
          }
        )
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
