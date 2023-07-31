import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AboutUsComponent } from './components/aboutUs/aboutUs.component';
import { CartComponent } from './components/cart/cart.component';
import { BlogComponent } from './components/blog/blog.component';
import { MyAccountComponent } from './components/my_account/myAccount.component';
import { RegisterComponent } from './components/register/register.component';
import { PricesComponent } from './components/prices/prices.component';
import { ContactComponent } from './components/contact/contact.component';
import { PaidComponent } from './components/paid/paid.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'aboutUs', component: AboutUsComponent},
  {path: 'cart', component: CartComponent},
  {path: 'blog', component: BlogComponent},
  {path: 'my_account', component: MyAccountComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'detail', component: PricesComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'paid', component: PaidComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
