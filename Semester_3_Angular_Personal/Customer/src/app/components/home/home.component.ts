import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from 'src/app/models/account.model';
import { Cart } from 'src/app/models/cart.model';
import { Product } from 'src/app/models/product.model';
import { AccountService } from 'src/app/services/account.service';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  products: Product[];
  product2s: Product[];
  account: Account;
  email: string;
  addToCart: FormGroup;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private accountService: AccountService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.addToCart = this.formBuilder.group({
      accountId: '',
      productId: '',
      quantity: 1,
      status: true,
    });
    
    this.productService.findAll().then(
      (result) => {
        console.log(result);
        this.products = result as Product[];
      },
      (error) => {
        console.log(error);
      }
    );

    this.productService.findTwo().then(
      (result) => {
        console.log(result);
        this.product2s = result as Product[];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  add(id: any) { //productId
    // console.log(id);
    this.email = localStorage.getItem('email');
    if(this.email != null){
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
    }else{
      if(confirm("You need to log in to make a purchase. Log in now?")){
        this.router.navigate(['/my_account']);
      }
    }
  }
}
