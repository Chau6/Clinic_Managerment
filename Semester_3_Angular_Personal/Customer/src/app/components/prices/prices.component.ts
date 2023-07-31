import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Account } from 'src/app/models/account.model';
import { Cart } from 'src/app/models/cart.model';
import { Product } from 'src/app/models/product.model';
import { AccountService } from 'src/app/services/account.service';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './prices.component.html',
})
export class PricesComponent implements OnInit {
  product: Product;
  account: Account;
  email: string;
  addToCart: FormGroup;

  constructor(
    private productService: ProductService,
    private activatedRoute: ActivatedRoute,
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
    
    this.activatedRoute.paramMap.subscribe((p) => {
      var id = p.get('id');
      this.productService.find(id).then(
        (result) => {
          this.product = result as Product; //ép kết quả về thành products
          console.log(this.product);
        },
        (error) => {
          console.log(error);
        }
      );
    });
  }

  add(id: any) {
    //productId
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
          (result) => {
            console.log(result);
            if (result) {
              alert('Add to Cart Successful');
            }
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
}
