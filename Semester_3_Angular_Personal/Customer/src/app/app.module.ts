import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AboutUsComponent } from './components/aboutUs/aboutUs.component';
import { CartComponent } from './components/cart/cart.component';
import { BlogComponent } from './components/blog/blog.component';
import { MyAccountComponent } from './components/my_account/myAccount.component';
import { RegisterComponent } from './components/register/register.component';
import { PricesComponent } from './components/prices/prices.component';
import { ContactComponent } from './components/contact/contact.component';
import { CategoryComponent } from './category.component';
import { PromotionComponent } from './promotion.component';
import { BaseURLService } from './services/baseUrl.service';
import { CategoryService } from './services/category.service';
import { OrderService } from './services/order.service';
import { ProductService } from './services/product.service';
import { AccountService } from './services/account.service';
import { CartService } from './services/cart.service';
import { PaidComponent } from './components/paid/paid.component';
import { BlogService } from './services/blog.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutUsComponent,
    CartComponent,
    BlogComponent,
    MyAccountComponent,
    RegisterComponent,
    PricesComponent,
    ContactComponent,
    CategoryComponent,
    PromotionComponent,
    PaidComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    AccountService,
    BaseURLService,
    CategoryService,
    OrderService,
    ProductService,
    CartService,
    BlogService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
